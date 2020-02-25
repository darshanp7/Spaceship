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

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isPushingBack)
        {
            Vector3 direction = Vector3.up * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            rigidBody.velocity = (Time.fixedDeltaTime * speed * direction); 
        }
        if(transform.position.x > 5)
        {
            PushBack();
        }
    }

    private void PushBack()
    {
        SpaceshipEventsBroker.CallPushBack();
        isPushingBack = true;
        rigidBody.velocity = (Vector3.left * pushBackSpeed);
        isPushingBack = false;
    }
}
