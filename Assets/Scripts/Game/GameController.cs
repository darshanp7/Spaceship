using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Level Definitions")]
    [Space]
    [SerializeField]
    private LevelDefinition[] levels;
    [Space]
    [Header("Current Level to be loaded")]
    [SerializeField]
    private int currentLevelIndex = 0;

    private GameObject obstacles;
    private GameObject collectibles;

    public LevelDefinition CurrentLevel { get; private set; }
    private float TimeLeftInLevel { get; set; }
    public bool AllObstaclesGenerated { get; set; }
    public bool AllCollectiblesGenerated { get; set; }

    private void Awake()
    {
        collectibles = GameObject.FindGameObjectWithTag("Collectibles");
        obstacles = GameObject.FindGameObjectWithTag("Obstacles");
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("TotalLevels", levels.Length);
        AllCollectiblesGenerated = false;
        AllObstaclesGenerated = false;
        currentLevelIndex = GetCurrentLevelIndex();
        StartLevel(currentLevelIndex);      
    }

    private void Update()
    {
        //TimeLeftInLevel -= Time.deltaTime;
        //if (TimeLeftInLevel < 0) EndLevel();
        if (CheckLevelEnded())
            EndLevel();
    }

    private void StartLevel(int level)
    {
        CurrentLevel = levels[level];
        TimeLeftInLevel = CurrentLevel.LevelDuration;
    }

    private void EndLevel()
    {
        
        enabled = false;

        if(currentLevelIndex < levels.Length)
        {
            currentLevelIndex++;
            Debug.Log("Current Level Index " + currentLevelIndex);
            PlayerPrefs.SetInt("LevelProgress", currentLevelIndex);
            GameControllerEventsBroker.CallLevelEnded();
        }
    }

    private bool CheckLevelEnded()
    {
        return obstacles.transform.childCount == 0 // No Obstacles currently on the screen
            && collectibles.transform.childCount == 0 // No Collectibles currently on the screen
            && AllCollectiblesGenerated && AllCollectiblesGenerated; //All the obstacles and collectibles for this level has been generated
    }

    private int GetCurrentLevelIndex()
    {
        int level = PlayerPrefs.GetInt("LevelProgress");
        if(level >= levels.Length)
        {
            return levels.Length - 1;
        }
        else
        {
            return level;
        }
    }
}
