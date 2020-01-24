using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBreakAnimation : MonoBehaviour
{
    public void OnAnimationEnd()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
