using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;//Declare the rigidbody2d of the object
    [SerializeField] float speed = 500f;//Speed of the ball

    [SerializeField] bool inGame;//boolean type for in game or not
    [SerializeField] Transform ballStartPosition;//Properties of ballStartPosition
    
    GameManager gameManager;//declare gameManager

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();//Reach the RB2D inside the object (Ball)
        gameManager = Object.FindObjectOfType<GameManager>();//reach gameManager
    }
    void Update()
    {
        if (gameManager.gameOver)//if game over
        {
            return;//exit the code
        }
        if(!inGame)//if the game has started
        {
            transform.position = ballStartPosition.position;//take the pos of ball to the ballHolder
        }

        if(Input.GetButtonDown("Jump") && !inGame)//if space (all platforms jump button) pressed, and not in Game
        {
            inGame = true;//declare the game has started
            rb.AddForce(Vector2.up * speed);//Add force to the rigidbody of the object (Ball)
        }

    }
    private void OnTriggerEnter2D(Collider2D target)//When the target is triggered
    {
        if(target.tag == "Bottom")//if the tag of the target is "Bottom"
        {
            rb.velocity = Vector2.zero;//end the velocity of the rigidBody2D

            gameManager.UpdateLives(-1);//on bottom colliider, decrease lives by one
            inGame = false;//Declare the game has ended.
        }    
    }
}
