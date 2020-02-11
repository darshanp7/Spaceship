using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float spawnDelay;
    public int maxEnemiesOnScreen;

    private SpriteRenderer spawnArea;
    private float xMax;
    private float yMax;
    private float xMin;
    private float yMin;

    private void Start()
    {
        InitializeSpawnAreaCorners();
        StartCoroutine(SpawnDelay());
        InvokeRepeating("Spawn", 1, 4);
    }
    
    private void Update()
    {
        
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
        return new Vector3(Random.Range(xMax, xMin), Random.Range(yMax, yMin), 0);
    }

    private IEnumerator SpawnDelay()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnDelay);
        yield return wait;
    }

    private void Spawn()
    {
        GameObject obstacle = Instantiate(obstacles[1], GetRandomPointInSpawnArea(), Quaternion.identity);
        obstacle.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 50);   
    }
}
