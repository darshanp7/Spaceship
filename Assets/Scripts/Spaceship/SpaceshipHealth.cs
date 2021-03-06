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

    private void Update()
    {
        if(health <= 0)
        {
            SpaceshipEventsBroker.CallDie();
            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 100;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            float damageTaken = collision.gameObject.GetComponent<Obstacle>().GetDamageToBeInflicted();
            health += damageTaken;
            SpaceshipEventsBroker.CallHitByAsteroid(damageTaken);
        }
    }
}
