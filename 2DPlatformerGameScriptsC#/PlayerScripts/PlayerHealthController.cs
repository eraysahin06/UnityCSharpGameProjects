using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    UIController uIController;

    public float unBeatenTime;
    float unBeatenTimer;
    PlayerController playerController;
    SpriteRenderer sr;
    [SerializeField] GameObject PlayerDead;
    private void Awake()
    {
        uIController = Object.FindObjectOfType<UIController>();
        sr = GetComponent<SpriteRenderer>();
        playerController =Object.FindObjectOfType<PlayerController>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        unBeatenTimer -= Time.deltaTime;

        if(unBeatenTimer <= 0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
    }
    public void GetDamage()
    {
        if(unBeatenTimer <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);
                Instantiate(PlayerDead, transform.position, transform.rotation);
            }
            else
            {
                unBeatenTimer = unBeatenTime;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
                playerController.FeedBack();
            }
            uIController.UpdateHealth();
        }  
    }  
    
    public void IncreaseHealth()
    {
        currentHealth++;

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        uIController.UpdateHealth();
    }
}
