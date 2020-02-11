using System;
using UnityEngine;

[Serializable]
public class ObstacleSpawnData
{
    [SerializeField] private GameObject obstacle;
    public GameObject Obstacle => obstacle;
    [SerializeField] private float spawnTime;
    public float SpawnTime => spawnTime;   
}
