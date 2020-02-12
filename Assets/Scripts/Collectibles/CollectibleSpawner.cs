using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public Spawner spawner;

    private GameController gameController;
    private float nextSpawnTime;
    private int collectibleIndex = -1;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Start()
    {
        nextSpawnTime = gameController.CurrentLevel.CollectibleSpawnData[++collectibleIndex].SpawnTime;
    }

    private void Update()
    {
        if (Time.time > nextSpawnTime && collectibleIndex < gameController.CurrentLevel.CollectibleSpawnData.Length)
        {
            Spawn(gameController.CurrentLevel.CollectibleSpawnData[collectibleIndex].Collectible);
            if (collectibleIndex < gameController.CurrentLevel.CollectibleSpawnData.Length)
            {
                nextSpawnTime = gameController.CurrentLevel.CollectibleSpawnData[++collectibleIndex].SpawnTime; 
            }
            else
            {
                gameController.AllCollectiblesGenerated = true;
                nextSpawnTime = Mathf.Infinity;
            }
        }
    }
    
    private void Spawn(GameObject objectToSpawn)
    {
        GameObject collectible = Instantiate(objectToSpawn, spawner.GetRandomPointInSpawnArea(), Quaternion.identity, GameObject.FindGameObjectWithTag("Collectibles").transform);
        collectible.GetComponent<Rigidbody2D>().AddForce(Vector3.left * collectible.GetComponent<Collectible>().Speed);
    }
}
