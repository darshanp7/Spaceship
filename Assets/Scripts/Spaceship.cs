using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spaceship : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    public float speed;
    public VariableJoystick variableJoystick;


    //To be refactored Later
    int goldCount;
    int silverCount;
    int bronzeCount;

    public Text goldCountText;
    public Text silverCountText;
    public Text bronzeCountText;

    public UIBarScript healthBar;
    public UIBarScript energyBar;

    public AsteroidGenerator asteroidGenerator;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(healthBar.NewValue < 0 || energyBar.NewValue < 0)
        {
            OnGameOver();
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = Vector3.up * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rigidBody.velocity = (direction * speed * Time.fixedDeltaTime);
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
        if(collision.gameObject.tag == "Obstacle")
        {
             healthBar.NewValue -= 0.1f; 
        }
    }

    public void OnGameOver()
    {
        asteroidGenerator.StopSpawning();
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 20;
    }

    //public void OnSwipeSouth()
    //{
    //    rigidBody.AddForce(force * Vector2.down);
    //}

    //public void OnSwipeNorth()
    //{
    //    rigidBody.AddForce(force * Vector2.up);
    //}

    //public void OnSwipeEast()
    //{
    //    rigidBody.AddForce(force * Vector2.right);
    //}

    //public void OnSwipeWest()
    //{
    //    rigidBody.AddForce(force * Vector2.left);
    //}

    //public void OnSwipeSouthEast()
    //{
    //    rigidBody.AddForce(new Vector2(force / 2 * 1, force / 2 * -1));
    //}

    //public void OnSwipeSouthWest()
    //{
    //    rigidBody.AddForce(new Vector2(force / 2 * -1, force / 2 * -1));
    //}

    //public void OnSwipeNorthEast()
    //{
    //    rigidBody.AddForce(new Vector2(force / 2 * 1, force / 2 * 1));
    //}

    //public void OnSwipeNorthWest()
    //{
    //    rigidBody.AddForce(new Vector2(force / 2 * -1, force / 2 * 1));
    //}
}
