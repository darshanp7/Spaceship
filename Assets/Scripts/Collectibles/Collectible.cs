using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    [SerializeField]
    private int pointsAwarded;
    public float Speed { get; protected set; }

}
