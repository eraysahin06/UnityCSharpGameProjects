using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] float speed;//speed of the paddle
    [SerializeField] float leftBoundary, rightBoundary;//left, right boundary values
    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Update()
    {

        if(gameManager.gameOver)//if game over
        {
            return;//exit the code
        }

        float h = Input.GetAxis("Horizontal");//equalize 'h' as "Horizontal Axis"

        //MOVE
        transform.Translate(Vector2.right.normalized * h * Time.deltaTime * speed);//translate the pos of item 
                                                                        //to direction*axis*time*speed
        //CREATE BOUNDARIES
        if (transform.position.x < leftBoundary)//if left boundary is passed (negative value)
        {
            transform.position = new Vector2(leftBoundary, transform.position.y);//adjust position as: X - left boundary 
                                                                                 //Y - normal value of Y value
        }
        if (transform.position.x > rightBoundary)//if right boundary is passed (positive value)
        {
            transform.position = new Vector2(rightBoundary, transform.position.y);//adjust position as: X - left boundary 
                                                                                 //Y - normal value of Y value
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "lifeIncreaser")
        {
            gameManager.UpdateLives(1);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "scoreIncreaser")
        {
            gameManager.UpdateScore(30);
            Destroy(other.gameObject);
        }
    }
}
