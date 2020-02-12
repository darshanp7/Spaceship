using System;
using UnityEngine;

[Serializable]
public class CollectibleSpawnData
{
    [SerializeField]
    private GameObject collectible;
    public GameObject Collectible => collectible;
    [SerializeField]
    private float spawnTime;
    public float SpawnTime => spawnTime;
}
