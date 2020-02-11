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

    private void Start()
    {
        StartLevel(currentLevelIndex);
    }

    private void Update()
    {
        TimeLeftInLevel -= Time.deltaTime;
        if (TimeLeftInLevel < 0) EndLevel();
    }

    private void StartLevel(int currentLevelIndex)
    {
        CurrentLevel = levels[currentLevelIndex];
        TimeLeftInLevel = CurrentLevel.LevelDuration;
    }

    private void EndLevel()
    {
        currentLevelIndex++;

        if(currentLevelIndex < levels.Length)
        {
            //Load Next Level
        }
    }
}
