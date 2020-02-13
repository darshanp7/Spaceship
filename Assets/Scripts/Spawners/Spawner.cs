using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameController gameController;
    private SpriteRenderer spawnArea;
    private float xMax;
    private float yMax;
    private float xMin;
    private float yMin;
    
    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Start()
    {
        InitializeSpawnAreaCorners();
        StartCoroutine(SpawnDelay(gameController.CurrentLevel.InitialDelay));
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

    public Vector3 GetRandomPointInSpawnArea()
    {
        return new Vector3(UnityEngine.Random.Range(xMax, xMin), UnityEngine.Random.Range(yMax, yMin), 0);
    }

    public IEnumerator SpawnDelay(int delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);
        yield return wait;
    }
}
