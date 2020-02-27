using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceJunk : Obstacle
{
    public float angVelocity;

    private Rigidbody2D rigidBody;
    
    private static readonly int IsCollided = Animator.StringToHash("isCollided");

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        Animator breakAnimator = transform.GetComponent<Animator>();
        breakAnimator.SetBool(IsCollided, true);
    }

    private void Update()
    {
        rigidBody.angularVelocity = angVelocity;
        rigidBody.velocity = Vector3.left * 1;
    }
}
