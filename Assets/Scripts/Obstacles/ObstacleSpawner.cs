using System;
using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Spawner spawner;
    private GameController gameController;
    private float nextSpawnTime;
    private int objectIndex = -1;

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
        if(Time.time > nextSpawnTime && objectIndex < gameController.CurrentLevel.ObstacleSpawnData.Length)
        {
            Spawn(gameController.CurrentLevel.ObstacleSpawnData[objectIndex].Obstacle);
            nextSpawnTime = gameController.CurrentLevel.ObstacleSpawnData[++objectIndex].SpawnTime;
        }
        else
        {
            gameController.AllObstaclesGenerated = true;
        }
    }
    
    private void Spawn(GameObject objectToSpawn)
    {
        GameObject obstacle = Instantiate(objectToSpawn, spawner.GetRandomPointInSpawnArea(), Quaternion.identity, GameObject.FindGameObjectWithTag("Obstacles").transform);
        obstacle.GetComponent<Rigidbody2D>().AddForce(Vector3.left * obstacle.GetComponent<Obstacle>().Speed);
    }
}
