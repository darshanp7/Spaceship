using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Level Definitions")]
    [Space]
    [SerializeField]
    private LevelDefinition[] levels;
    [SerializeField]
    private int currentLevelIndex = 0;

    public LevelDefinition CurrentLevel { get; private set; }
    public float TimeLeftInLevel { get; private set; }
    public bool AllObstaclesGenerated { get; set; }
    public bool AllCollectiblesGenerated { get; set; }

    private void Awake()
    {
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

    private void StartLevel(int currentLevelIndex)
    {
        CurrentLevel = levels[currentLevelIndex];
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
        return GameObject.FindGameObjectWithTag("Obstacles").transform.childCount == 0
            && GameObject.FindGameObjectWithTag("Collectibles").transform.childCount == 0
            && AllCollectiblesGenerated && AllCollectiblesGenerated;
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
