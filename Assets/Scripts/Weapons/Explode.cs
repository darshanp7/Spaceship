using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public void OnExplodeAnimationFinish()
    {
        Destroy(this.transform.parent.parent.gameObject);
    }
}
