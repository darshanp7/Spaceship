using System;
using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Spawner spawner;
    private GameController gameController;
    private float nextSpawnTime;
    private int objectIndex = -1;
    private float timer = 0.0f;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }

    private void Start()
    {   
        nextSpawnTime = gameController.CurrentLevel.ObstacleSpawnData[++objectIndex].SpawnTime;
    }
    
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > nextSpawnTime && objectIndex < gameController.CurrentLevel.ObstacleSpawnData.Length && !gameController.AllObstaclesGenerated)
        {
            Spawn(gameController.CurrentLevel.ObstacleSpawnData[objectIndex].Obstacle);
            if ((objectIndex + 1) >= gameController.CurrentLevel.ObstacleSpawnData.Length)
            {
                gameController.AllObstaclesGenerated = true;
                return;
            }
            else
            {
                nextSpawnTime = gameController.CurrentLevel.ObstacleSpawnData[++objectIndex].SpawnTime;
            }
        }
    }
    
    private void Spawn(GameObject objectToSpawn)
    {
        GameObject obstacle = Instantiate(objectToSpawn, spawner.GetRandomPointInSpawnArea(), Quaternion.identity, GameObject.FindGameObjectWithTag("Obstacles").transform);
        obstacle.GetComponent<Rigidbody2D>().AddForce(Vector3.left * obstacle.GetComponent<Obstacle>().Speed);
    }
}
