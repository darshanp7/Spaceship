﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipHealth : MonoBehaviour
{
    private float maxHealth = 1.0f;
    private float health;

    private void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if(health <= 0)
        {
            SpaceshipEventsBroker.CallDie();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            health += -0.1f;
            SpaceshipEventsBroker.CallHitByAsteroid(-0.1f);
        }
    }
}