using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Collectible
{

    public float goldSpeed;

    private void Awake()
    {
        base.Speed = goldSpeed;
    }
}
