using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float speedMultiplier;
    
    Rigidbody2D rb;

    bool isGrounded;
    bool canDoubleJump;

    public float feedbackTime, feedbackPower;
    float feedbackTimer;
    bool isRightDir;
    public Transform groundControlPoint;
    public LayerMask groundLayerMask;

    Animator anim;
    public float bouncePower;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(feedbackTimer <= 0)
        {
            MoveCharacter();
            JumpCharacter();
            ChangeDirection();
        }
        else
        {
            feedbackTimer -= Time.deltaTime;

            if(isRightDir)
            {
                rb.velocity = new Vector2(-feedbackPower, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(feedbackPower, rb.velocity.y);
            }
        }
        anim.SetFloat("movementSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

    }

    void MoveCharacter()
    {
        float h = Input.GetAxis("Horizontal");
        float speed = h * movementSpeed;

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void JumpCharacter()
    {
        if(isGrounded)
        {
            canDoubleJump = true;
        }
        isGrounded = Physics2D.OverlapCircle(groundControlPoint.position, .2f, groundLayerMask);

        if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, speedMultiplier);
            }
            else if(canDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, speedMultiplier);
                canDoubleJump= false;
            }
            
        }

    }

    void ChangeDirection()
    {
        Vector2 geciciScale = transform.localScale;

        if (rb.velocity.x > 0)
        {
            isRightDir = true;
            geciciScale.x = 1f;
        }
        else if (rb.velocity.x < 0)
        {
            isRightDir = false;
            geciciScale.x = -1f;
        }
        transform.localScale = geciciScale;
    }

    public void FeedBack()
    {
        feedbackTimer = feedbackTime;
        rb.velocity = new Vector2(0, rb.velocity.y);

        anim.SetTrigger("GotDamage");
    }

    public void BounceOnTrigger()
    {
        rb.velocity = new Vector2(rb.velocity.x, bouncePower);
    }

}
