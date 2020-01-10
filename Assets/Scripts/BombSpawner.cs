using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bomb;

    void OnEnable()
    {
        Lean.Touch.LeanTouch.OnFingerTap += HandleFingerTap;
    }

    void OnDisable()
    {
        Lean.Touch.LeanTouch.OnFingerTap -= HandleFingerTap;
    }

    void HandleFingerTap(Lean.Touch.LeanFinger finger)
    {
        Debug.Log("You just tapped the screen with finger " + finger.Index + " at " + finger.ScreenPosition);
        GameObject bombInstance = Instantiate(bomb, this.transform.position, Quaternion.identity);
        bombInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
    }
}
