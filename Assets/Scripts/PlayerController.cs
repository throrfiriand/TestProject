using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float speed;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0) //it is positive
        {
            rigidbody2d.velocity = new Vector2(speed, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0) //it is negative
        {
            rigidbody2d.velocity = new Vector2(-speed, 0f);
        }

        else if (Input.GetAxis("Vertical") > 0) //it is positive
        {
            rigidbody2d.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0) //it is negative
        {

            rigidbody2d.velocity = new Vector2(0f, -speed);
        }
        else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            //stop
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Door")
        Debug.Log("Level Complete!!!");
    }

}