using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public int speed;
    private float parallaxLayerLength;
    private Vector3 startPos;

    void Start()
    {
        parallaxLayerLength = GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = transform.position;
        //Debug.Log("Length of this Parallax Layer " + this.gameObject.name + " " + parallaxLayerLength);
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
        if(Mathf.Abs(transform.position.x) > parallaxLayerLength)
        {
            transform.position = new Vector3(startPos.x + parallaxLayerLength, 0, 0);
        }
    }
}
