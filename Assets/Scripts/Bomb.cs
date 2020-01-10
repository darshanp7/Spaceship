﻿using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject explodePrefab;
    Animator explodeAnimator;
    float explodeTime;

    void Start()
    {
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explode = Instantiate(explodePrefab, this.transform);
        explodeAnimator = explode.GetComponentInChildren<Animator>();
        RuntimeAnimatorController runAc = explodeAnimator.runtimeAnimatorController;
        for (int i = 0; i < runAc.animationClips.Length; i++)
        {
            if (runAc.animationClips[i].name == "Explosion")
            {
                explodeTime = runAc.animationClips[i].length;
            }
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        explodeAnimator.SetBool("isTouchGround", true);
    }
}
