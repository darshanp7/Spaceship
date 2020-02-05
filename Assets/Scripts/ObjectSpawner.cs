using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private float xMax;
    private float yMax;
    private float xMin;
    private float yMin;

    private float spawnTimer;

    private bool isSpawn = true;

    private void OnEnable()
    {
        SpaceshipEventsBroker.Die += StopSpawning;
    }

    private void OnDisable()
    {
        SpaceshipEventsBroker.Die -= StopSpawning;
    }

    private void Start()
    {
        xMax = GetComponent<SpriteRenderer>().bounds.max.x;
        xMin = GetComponent<SpriteRenderer>().bounds.min.x;
        yMax = GetComponent<SpriteRenderer>().bounds.max.y;
        yMin = GetComponent<SpriteRenderer>().bounds.min.y;
    }

    public void StartSpawing()
    {
        isSpawn = true;
    }

    public void StopSpawning()
    {
        isSpawn = false;
    }

    public void Spawn(GameObject objectToBeSpawned, int minimumWaitTimeToSpawn, int maximumWaitTimeToSpawn, float force)
    {
        if (isSpawn)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                spawnTimer += Random.Range(minimumWaitTimeToSpawn, maximumWaitTimeToSpawn);
                GameObject asteroid = Instantiate(objectToBeSpawned, new Vector3(Random.Range(xMax, xMin), Random.Range(yMax, yMin), 0), Quaternion.identity);
                asteroid.GetComponent<Rigidbody2D>().AddForce(Vector3.left * force);
            } 
        }
    }
}
