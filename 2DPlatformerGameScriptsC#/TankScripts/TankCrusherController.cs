using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCrusherController : MonoBehaviour
{
    PlayerController playerController;
    TankController tankController;
    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        tankController = Object.FindObjectOfType<TankController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && playerController.transform.position.y > transform.position.y)
        {
            playerController.BounceOnTrigger();
            tankController.getHit();
            gameObject.SetActive(false);
        }
    }
}
