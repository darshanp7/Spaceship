using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bombSpawnTransform;
    
    public void Fire()
    {
        GameObject bombInstance = Instantiate(bombPrefab, bombSpawnTransform.position, Quaternion.identity);
        bombInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 400);
        SpaceshipEventsBroker.CallFireWeapon(-0.05f);
    }
}
