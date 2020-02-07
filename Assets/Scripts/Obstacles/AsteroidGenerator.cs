using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject goldAsteroidPrefab;
    public GameObject silverAsteroidPrefab;
    public GameObject bronzeAsteroidPrefab;

    public int minimumAsteroidSpawnTime;
    public int maximumAsteroidSpawnTime;
    public int minimumGoldSpawnTime;
    public int maximumGoldSpawnTime;
    public int minimumSilverSpawnTime;
    public int maximumSilverSpawnTime;
    public int minimumBronzeSpawnTime;
    public int maximumBronzeSpawnTime;

    float xMax;
    float yMax;
    float xMin;
    float yMin;

    float spawnTimer = 0;
    float goldSpawnTimer = 15;
    float silverSpawnTimer = 10;
    float bronzeSpawnTimer = 5;
    float initialWaitTime = 10;

    bool isSpawn = true;

    public void StartSpawing()
    {
        isSpawn = true;
    }

    public void StopSpawning()
    {
        isSpawn = false;
    }

    private void OnEnable()
    {
        SpaceshipEventsBroker.Die += StopSpawning;
    }

    private void OnDisable()
    {
        SpaceshipEventsBroker.Die -= StopSpawning;
    }

    void Start()
    {
        xMax = GetComponent<SpriteRenderer>().bounds.max.x;
        xMin = GetComponent<SpriteRenderer>().bounds.min.x;
        yMax = GetComponent<SpriteRenderer>().bounds.max.y;
        yMin = GetComponent<SpriteRenderer>().bounds.min.y;
    }

    void Update()
    {
        initialWaitTime -= Time.deltaTime;
        if (isSpawn)
        {
            SpawnAsteroids();
            if (initialWaitTime < 0)
            {
                SpawnCollectibles(); 
            }
        }
    }

    private void SpawnCollectibles()
    {
        SpawnGold();
        SpawnSilver();
        SpawnBronze();
    }

    void SpawnAsteroids()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            spawnTimer += Random.Range(minimumAsteroidSpawnTime, maximumAsteroidSpawnTime);
            GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(Random.Range(xMax, xMin), Random.Range(yMax, yMin), 0), Quaternion.identity);
            asteroid.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 50);
        }
    }

    void SpawnGold()
    {
        goldSpawnTimer -= Time.deltaTime;
        if (goldSpawnTimer <= 0)
        {
            goldSpawnTimer += Random.Range(minimumGoldSpawnTime, maximumGoldSpawnTime);
            GameObject asteroid = Instantiate(goldAsteroidPrefab, new Vector3(Random.Range(xMax, xMin), Random.Range(yMax, yMin), 0), Quaternion.identity);
            asteroid.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 100);
        }
    }

    void SpawnSilver()
    {
        silverSpawnTimer -= Time.deltaTime;
        if (silverSpawnTimer <= 0)
        {
            silverSpawnTimer += Random.Range(minimumSilverSpawnTime, maximumSilverSpawnTime);
            GameObject asteroid = Instantiate(silverAsteroidPrefab, new Vector3(Random.Range(xMax, xMin), Random.Range(yMax, yMin), 0), Quaternion.identity);
            asteroid.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 100);
        }
    }

    void SpawnBronze()
    {
        bronzeSpawnTimer -= Time.deltaTime;
        if (bronzeSpawnTimer <= 0)
        {
            bronzeSpawnTimer += Random.Range(minimumBronzeSpawnTime, maximumBronzeSpawnTime);
            GameObject asteroid = Instantiate(bronzeAsteroidPrefab, new Vector3(Random.Range(xMax, xMin), Random.Range(yMax, yMin), 0), Quaternion.identity);
            asteroid.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 100);
        }
    }
}
