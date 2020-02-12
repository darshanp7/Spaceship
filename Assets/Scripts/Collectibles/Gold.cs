using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Collectible
{

    public float goldSpeed;

    void Awake()
    {
        base.Speed = goldSpeed;
    }
    
    void Update()
    {
        
    }
}
