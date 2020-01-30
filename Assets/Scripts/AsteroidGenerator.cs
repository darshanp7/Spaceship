using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Asteroids
{
    rock,
    gold,
    silver,
    bronze
}

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
    float goldSpawnTimer = 0;
    float silverSpawnTimer = 0;
    float bronzeSpawnTimer = 0;

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
        if (isSpawn)
        {
            SpawnAsteroids();
            SpawnGold();
            SpawnSilver();
            SpawnBronze(); 
        }
    }

    //void SpawnAsteroid(Asteroids asteroidType, )
    //{
    //    spawnTimer -= Time.deltaTime;
    //    if (spawnTimer <= 0)
    //    {
    //        spawnTimer += Random.Range(minimumAsteroidSpawnTime, maximumAsteroidSpawnTime);
    //        GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(Random.Range(xMax, xMin), Random.Range(yMax, yMin), 0), Quaternion.identity);
    //        asteroid.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 50);
    //    }
    //}

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
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer += Random.Range(minimumGoldSpawnTime, maximumGoldSpawnTime);
            GameObject asteroid = Instantiate(goldAsteroidPrefab, new Vector3(Random.Range(xMax, xMin), Random.Range(yMax, yMin), 0), Quaternion.identity);
            asteroid.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 100);
        }
    }

    void SpawnSilver()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer += Random.Range(minimumSilverSpawnTime, maximumSilverSpawnTime);
            GameObject asteroid = Instantiate(silverAsteroidPrefab, new Vector3(Random.Range(xMax, xMin), Random.Range(yMax, yMin), 0), Quaternion.identity);
            asteroid.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 100);
        }
    }

    void SpawnBronze()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer += Random.Range(minimumBronzeSpawnTime, maximumBronzeSpawnTime);
            GameObject asteroid = Instantiate(bronzeAsteroidPrefab, new Vector3(Random.Range(xMax, xMin), Random.Range(yMax, yMin), 0), Quaternion.identity);
            asteroid.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 100);
        }
    }
}
