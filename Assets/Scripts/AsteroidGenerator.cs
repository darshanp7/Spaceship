using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int minimumSpawnTime = 10;
    public int maximumSpawnTime = 20;

    float xMax;
    float yMax;
    float xMin;
    float yMin;

    float spawnTimer = 0;

    void Start()
    {
        xMax = GetComponent<SpriteRenderer>().bounds.max.x;
        xMin = GetComponent<SpriteRenderer>().bounds.min.x;
        yMax = GetComponent<SpriteRenderer>().bounds.max.y;
        yMin = GetComponent<SpriteRenderer>().bounds.min.y;
    }

    void Update()
    {     
        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            spawnTimer += Random.Range(minimumSpawnTime, maximumSpawnTime);
            GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(Random.Range(xMax, xMin), Random.Range(yMax, yMin), 0), Quaternion.identity);
            asteroid.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 50);
        }
    }
}
