using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float damageInflicted;

    public float getDamageInflicted()
    {
        return damageInflicted;
    }
}
