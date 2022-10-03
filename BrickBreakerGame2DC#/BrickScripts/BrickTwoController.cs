using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickTwoController : MonoBehaviour
{
    [SerializeField] private Sprite brokenSprite;//create a s.field to choose brokenSprite
    [SerializeField] GameObject brick2Effect;//create a s.field to choose brick2Effect(green)
    [SerializeField] GameObject scoreIncreaser;
    int count;//Collide counter

    GameManager gameManager;//get game manager

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();//get game manager
    }
    private void Start()
    {
        count = 0;//declare count as 0 at first
    }

    private void OnCollisionEnter2D(Collision2D target)//on collision enter
    {
        if(target.gameObject.tag == "Ball")//if the target tag is "Ball"
        {
            count++;//increase count by one
            if(count==1)//if hit count = 1
            {
                GetComponent<SpriteRenderer>().sprite = brokenSprite;//change sprite of the object to brokenSprite
            }
            else if(count==2)//if hit count = 2
            {
                Instantiate(brick2Effect, transform.position, transform.rotation);//instantiate brick effect on pos., rot.
                gameManager.UpdateScore(10);
                int randomChance = Random.Range(1, 101);

                if (randomChance > 60)
                {
                    Instantiate(scoreIncreaser, transform.position, transform.rotation);
                }
                Destroy(gameObject);//Destroy the object
            }
        }
    }
}
