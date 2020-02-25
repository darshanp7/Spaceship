using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Obstacle
{
    public float asteroidSpeed;
    private static readonly int IsCollided = Animator.StringToHash("isCollided");

    private void Awake()
    {
        base.Speed = asteroidSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        Animator asteroidBreakAnimator = transform.GetChild(0).GetComponent<Animator>();
        asteroidBreakAnimator.SetBool(IsCollided, true);
    }
}
