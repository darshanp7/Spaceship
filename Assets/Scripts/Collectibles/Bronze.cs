using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bronze : Collectible
{

    public float bronzeSpeed;

    private void Start()
    {
        base.Speed = bronzeSpeed;
    }
}
