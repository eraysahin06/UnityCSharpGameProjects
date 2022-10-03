using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] GameObject brickEffect; //get particle effect: brickEffect
    [SerializeField] GameObject lifeIncreaser;
    
    GameManager gameManager;//get game manager

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();//get game manager
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag=="Ball")//if the tag of the collided object is "Ball"
        {
            Instantiate(brickEffect, transform.position, transform.rotation);//instantiate effect in collision position and rotation

            gameManager.UpdateScore(5);//update the score as +5

            int randomChance = Random.Range(1, 101);

            if (randomChance > 60)
            {
                Instantiate(lifeIncreaser, transform.position, transform.rotation);
            }
            
            Destroy(gameObject);//Destroy the brick
        }
    }
}
