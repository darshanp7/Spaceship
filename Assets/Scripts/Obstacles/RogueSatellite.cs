using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueSatellite : Obstacle
{
    public float angVelocity;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        Animator asteroidBreakAnimator = transform.GetChild(0).GetComponent<Animator>();
        asteroidBreakAnimator.SetBool("isCollided", true);
    }

    void Update()
    {
        rigidBody.angularVelocity = angVelocity;
        rigidBody.velocity = Vector3.left * 1;
    }
}
