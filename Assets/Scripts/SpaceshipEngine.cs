using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipEngine : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 direction = Vector3.up * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rigidBody.velocity = (direction * speed * Time.fixedDeltaTime);
    }
}
