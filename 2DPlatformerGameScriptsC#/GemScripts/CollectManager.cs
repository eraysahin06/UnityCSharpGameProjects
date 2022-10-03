using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    [SerializeField] bool isGem, isCherry;
    [SerializeField] GameObject collectEffect;
    bool isCollected;
    LevelManager levelManager;

    UIController uiController;

    PlayerHealthController playerHealthController;
    

    private void Awake()
    {
        levelManager = Object.FindObjectOfType<LevelManager>();
        uiController = Object.FindObjectOfType<UIController>();
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isCollected)
        {
            if(isGem)
            {
                levelManager.collectedGemNo++;
                isCollected = true;
                Destroy(gameObject);
                uiController.UpdateGemNumber();
                Instantiate(collectEffect, transform.position, transform.rotation);
            }
            if(isCherry)
            {
                if(playerHealthController.currentHealth != playerHealthController.maxHealth)
                {                   
                    isCollected = true;
                    Destroy(gameObject);
                    playerHealthController.IncreaseHealth();
                    Instantiate(collectEffect, transform.position, transform.rotation);

                }
            }

        }
    }
}
