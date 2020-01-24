using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Debug.Log(this.gameObject.name + " is invisible");
        Destroy(this.gameObject);
    }
}
