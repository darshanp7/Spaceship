using UnityEngine;

[CreateAssetMenu(menuName = "Custom/New Level Definition", fileName = "LevelDefinition")]
public class LevelDefinition : ScriptableObject
{
    [SerializeField] private string levelName;
    public string LevelName => levelName;

    [SerializeField] private float levelDuration;
    public float LevelDuration => levelDuration;
    
    [SerializeField] private bool hasPowerUps;
    public bool HasPowerUps => hasPowerUps;

    [SerializeField] private int initialDelay;
    public int InitialDelay => initialDelay;

    [SerializeField] private ObstacleSpawnData[] obstacleSpawnData;
    public ObstacleSpawnData[] ObstacleSpawnData => obstacleSpawnData;

    [SerializeField]
    private CollectibleSpawnData[] collectibleSpawnData;
    public CollectibleSpawnData[] CollectibleSpawnData => collectibleSpawnData;
}

