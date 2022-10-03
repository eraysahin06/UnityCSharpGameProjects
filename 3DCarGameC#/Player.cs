using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MoevementJS movementJS;
    public float playerSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementJS.joystickVec.y != 0)
        {
            rb.velocity = new Vector2 (movementJS.joystickVec.x * playerSpeed, movementJS.joystickVec.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
