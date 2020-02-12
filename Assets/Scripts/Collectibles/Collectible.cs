using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    [SerializeField]
    private int pointsAwarded;
    [SerializeField]
    private float spawnRate;

    public float Speed { get; protected set; }

}
