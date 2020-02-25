using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float damageInflicted;
    [SerializeField]
    private float spawnRate;

    public float Speed { get; protected set; }

    public float GetDamageToBeInflicted()
    {
        return damageInflicted;
    }
}
