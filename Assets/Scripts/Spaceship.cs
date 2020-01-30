using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spaceship : MonoBehaviour
{
    
    //To be refactored Later
    int goldCount;
    int silverCount;
    int bronzeCount;

    public Text goldCountText;
    public Text silverCountText;
    public Text bronzeCountText;

    public AsteroidGenerator asteroidGenerator;

    void Start()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Gold")
        {
            Destroy(collision.gameObject);
            goldCount += 1;
            goldCountText.text = goldCount.ToString();
        }
        if(collision.gameObject.tag == "Silver")
        {
            Destroy(collision.gameObject);
            silverCount += 1;
            silverCountText.text = silverCount.ToString();
        }
        if(collision.gameObject.tag == "Bronze")
        {
            Destroy(collision.gameObject);
            bronzeCount += 1;
            bronzeCountText.text = bronzeCount.ToString();
        }
    } 
}
