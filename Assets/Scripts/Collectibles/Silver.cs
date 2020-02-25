using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silver : Collectible
{
    public float silverSpeed;

    private void Awake()
    {
        base.Speed = silverSpeed;
    }
}
