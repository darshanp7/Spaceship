using System;
using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;

    private GameController gameController;
    private SpriteRenderer spawnArea;
    private float xMax;
    private float yMax;
    private float xMin;
    private float yMin;
    private float nextSpawnTime;
    private int objectIndex = -1;

    private void Awake()
    {
        gameController = GetComponentInParent<GameController>();
    }

    private void Start()
    {
        InitializeSpawnAreaCorners();
        StartCoroutine(SpawnDelay(gameController.CurrentLevel.InitialDelay));
        nextSpawnTime = gameController.CurrentLevel.ObstacleSpawnData[++objectIndex].SpawnTime;
        //InvokeRepeating("Spawn", 1, 4);
    }
    
    private void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            Spawn(gameController.CurrentLevel.ObstacleSpawnData[objectIndex].Obstacle);
            nextSpawnTime = gameController.CurrentLevel.ObstacleSpawnData[++objectIndex].SpawnTime;
        }     
    }

    private void InitializeSpawnAreaCorners()
    {
        spawnArea = GetComponent<SpriteRenderer>();
        xMax = spawnArea.bounds.max.x;
        xMin = spawnArea.bounds.min.x;
        yMax = spawnArea.bounds.max.y;
        yMin = spawnArea.bounds.min.y;
    }

    private Vector3 GetRandomPointInSpawnArea()
    {
        return new Vector3(UnityEngine.Random.Range(xMax, xMin), UnityEngine.Random.Range(yMax, yMin), 0);
    }

    private IEnumerator SpawnDelay(int delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);
        yield return wait;
    }

    private void Spawn(GameObject obstacleToSpawn)
    {
        GameObject obstacle = Instantiate(obstacleToSpawn, GetRandomPointInSpawnArea(), Quaternion.identity);
        obstacle.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 50);   
    }
}
