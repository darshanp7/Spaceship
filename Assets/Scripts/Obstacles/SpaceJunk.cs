﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceJunk : Obstacle
{
    public float angVelocity;

    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidBody.angularVelocity = angVelocity;
        rigidBody.velocity = Vector3.left * 1;
    }
}
