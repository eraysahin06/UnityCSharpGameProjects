using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float ammoSpeed;

    PlayerHealthController healthController;

    private void Awake()
    {
       healthController = Object.FindObjectOfType<PlayerHealthController>();
    }
    private void Update()
    {
        transform.position += new Vector3(-ammoSpeed *transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            healthController.GetDamage();
        }

        Destroy(gameObject);
    }
}
