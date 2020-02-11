using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float damageInflicted;
    [SerializeField]
    private float spawnRate;

    public float getDamageToBeInflicted()
    {
        return damageInflicted;
    }
    
    public float getSpawnRate()
    {
        return spawnRate;
    }
}
