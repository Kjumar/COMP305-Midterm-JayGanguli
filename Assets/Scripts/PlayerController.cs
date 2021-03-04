using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 500f;

    [Header("ground Check")]
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator anim;

    private Vector3 originalScale;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        originalScale = transform.localScale;
    }


    void FixedUpdate()
    {
        isGrounded = GroundCheck();
        float horizontalMove = Input.GetAxis("Horizontal");

        anim.SetBool("isDucking", false);

        if (isGrounded)
        {
            anim.SetBool("isGrounded", true);

            if (Input.GetAxis("Jump") > 0)
            {
                // reset y velocity before adding our jump force. This is to prevent that weird jumping bug that launches the player into space
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(new Vector2(0f, jumpForce));
                isGrounded = false;
            }
        }
        else
        {
            anim.SetBool("isGrounded", false);
        }

        if (horizontalMove < 0)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
        else if (horizontalMove > 0)
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        }
        else
        {
            // this is the only scenario when the player can duck
            if (Input.GetAxis("Vertical") < 0)
            {
                anim.SetBool("isDucking", true);
            }
        }

        anim.SetFloat("xSpeed", Mathf.Abs(horizontalMove));

        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }
}
