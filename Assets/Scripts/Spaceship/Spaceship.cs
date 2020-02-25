using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spaceship : MonoBehaviour
{

    private const int collectiblesLayer = 11;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == collectiblesLayer)
        {
            SpaceshipEventsBroker.CallCaughtCollectibles(collision.gameObject.tag);
            Destroy(collision.gameObject);
        }
    } 
}
