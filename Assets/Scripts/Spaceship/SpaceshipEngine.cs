using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipEngine : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public float pushBackSpeed;
    private Rigidbody2D rigidBody;
    private bool isPushingBack = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isPushingBack)
        {
            Vector3 direction = Vector3.up * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            rigidBody.velocity = (direction * speed * Time.fixedDeltaTime); 
        }
        if(transform.position.x > 5)
        {
            PushBack();
        }
    }

    public void PushBack()
    {
        SpaceshipEventsBroker.CallPushBack();
        isPushingBack = true;
        rigidBody.velocity = (Vector3.left * pushBackSpeed);
        isPushingBack = false;
    }
}
