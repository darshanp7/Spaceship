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

    private void InitializeSpawnAreaCorners()
    {
        spawnArea = GetComponent<SpriteRenderer>();
        var bounds = spawnArea.bounds;
        xMax = bounds.max.x;
        xMin = bounds.min.x;
        yMax = bounds.max.y;
        yMin = bounds.min.y;
    }

    public Vector3 GetRandomPointInSpawnArea()
    {
        return new Vector3(UnityEngine.Random.Range(xMax, xMin), UnityEngine.Random.Range(yMax, yMin), 0);
    }

    private IEnumerator SpawnDelay(int delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);
        yield return wait;
    }
}
