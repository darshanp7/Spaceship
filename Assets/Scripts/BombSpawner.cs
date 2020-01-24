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
        //Fire(finger);
    }

    public void Fire()
    {
        GameObject bombInstance = Instantiate(bomb, new Vector3(this.transform.position.x, this.transform.position.y - 0.5f, 0), Quaternion.identity);
        bombInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 400);
        GetComponent<Spaceship>().energyBar.NewValue -= 0.05f;
    }
}
