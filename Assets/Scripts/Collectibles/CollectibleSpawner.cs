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
        if (Time.time > nextSpawnTime && collectibleIndex < gameController.CurrentLevel.CollectibleSpawnData.Length && !gameController.AllCollectiblesGenerated)
        {
            Spawn(gameController.CurrentLevel.CollectibleSpawnData[collectibleIndex].Collectible);
            if((collectibleIndex+1) >= gameController.CurrentLevel.CollectibleSpawnData.Length)
            {
                gameController.AllCollectiblesGenerated = true;
                return;
            }
            else
            {
                nextSpawnTime = gameController.CurrentLevel.CollectibleSpawnData[++collectibleIndex].SpawnTime;
            }
        }
    }
    
    private void Spawn(GameObject objectToSpawn)
    {
        GameObject collectible = Instantiate(objectToSpawn, spawner.GetRandomPointInSpawnArea(), Quaternion.identity, GameObject.FindGameObjectWithTag("Collectibles").transform);
        collectible.GetComponent<Rigidbody2D>().AddForce(Vector3.left * collectible.GetComponent<Collectible>().Speed);
    }
}
