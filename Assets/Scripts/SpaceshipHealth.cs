using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipHealth : MonoBehaviour
{
    private float maxHealth = 1.0f;
    private float health;

    public event Action Die;
    public event Action HitByAsteroid;

    void Update()
    {
        if(health <= 0)
        {
            if (Die != null)
                Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (HitByAsteroid != null)
                HitByAsteroid();
        }
    }
}
