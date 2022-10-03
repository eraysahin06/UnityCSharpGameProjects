using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOnHeadController : MonoBehaviour
{

    [SerializeField] GameObject deathEffect;
    PlayerController playerController;

    public float cherryChance;
    public GameObject cherry;

    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Frog"))
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect, transform.position, transform.rotation);

            playerController.BounceOnTrigger();

            float chanceRange = Random.Range(0, 100f);

            if(chanceRange <= cherryChance)
            {
                Instantiate(cherry, other.transform.position, other.transform.rotation);
            }
        }    
    }
}
