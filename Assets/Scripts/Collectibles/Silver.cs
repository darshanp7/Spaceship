using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silver : Collectible
{
    public float silverSpeed;

    void Awake()
    {
        base.Speed = silverSpeed;
    }
    
    void Update()
    {
        
    }
}
