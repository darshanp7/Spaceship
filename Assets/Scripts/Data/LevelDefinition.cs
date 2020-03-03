using UnityEngine;

[CreateAssetMenu(menuName = "Custom/New Level Definition", fileName = "LevelDefinition")]
public class LevelDefinition : ScriptableObject
{
//    [SerializeField] private string levelName;
//    public string LevelName => levelName;

    [field: SerializeField]
    public float LevelDuration { get; }

//    [SerializeField] private bool hasPowerUps;
//    public bool HasPowerUps => hasPowerUps;

    [field: SerializeField]
    public int InitialDelay { get; }

    [field: SerializeField]
    public ObstacleSpawnData[] ObstacleSpawnData { get; }

    [SerializeField]
    private CollectibleSpawnData[] collectibleSpawnData;
    public CollectibleSpawnData[] CollectibleSpawnData => collectibleSpawnData;
}

