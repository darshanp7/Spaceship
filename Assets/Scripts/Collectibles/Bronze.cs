using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bronze : Collectible
{

    public float bronzeSpeed;

    void Start()
    {
        base.Speed = bronzeSpeed;
    }
    
    void Update()
    {
        
    }
}
