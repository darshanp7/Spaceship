using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spaceship : MonoBehaviour
{

    private const int CollectiblesLayer = 11;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == CollectiblesLayer)
        {
            SpaceshipEventsBroker.CallCaughtCollectibles(collision.gameObject.tag);
            Destroy(collision.gameObject);
        }
    } 
}
