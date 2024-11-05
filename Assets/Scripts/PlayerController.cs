using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IPlayerController
{
    public GameObject GameWonPanel;
    public GameObject GameLostPanel;
    public Rigidbody2D rigidbody2d;
    public float speed;
    private bool isGameOver = false;
    void Update()
    {
        if (isGameOver == true)

        {
            return;

        }

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
        {
            Debug.Log("Level Complete!!");
            GameWonPanel.SetActive(true);
            isGameOver = true;
        }

        else if (other.tag == "Enemy")
        {
            Debug.Log("Level Lost!!");
            GameLostPanel.SetActive(true);
            isGameOver = true;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Button Clicked");
        Time.timeScale = 1;
    }
}





