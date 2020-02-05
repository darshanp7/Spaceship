using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        Animator asteroidBreakAnimator = transform.GetChild(0).GetComponent<Animator>();
        asteroidBreakAnimator.SetBool("isCollided", true);
    }
}
