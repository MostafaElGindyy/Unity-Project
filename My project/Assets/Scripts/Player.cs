using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    public KeyCode spacebar;
    public KeyCode keyLeft;
    public KeyCode keyRight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private Animator anim;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Check if components are assigned correctly
        if (anim == null) Debug.LogError("Animator component missing on Player.");
        if (rb2d == null) Debug.LogError("Rigidbody2D component missing on Player.");
        if (spriteRenderer == null) Debug.LogError("SpriteRenderer component missing on Player.");
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        Debug.Log("Grounded Status: " + grounded); // Debug log for grounded status
    }

    void Update()
    {
        if (anim != null)
        {
            anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
            anim.SetBool("Grounded", grounded);
        }

        if (Input.GetKeyDown(spacebar) && grounded)
        {
            Debug.Log("Jump key pressed and grounded"); // Debug log for jump key press
            Jump();
        }

        Debug.Log($"KeyLeft: {Input.GetKey(keyLeft)}, KeyRight: {Input.GetKey(keyRight)}");

        if (Input.GetKey(keyLeft))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = true;
            }
        }

        if (Input.GetKey(keyRight))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    private void Jump()
    {
        if (grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
            Debug.Log("Jump executed"); // Debug log for jump execution
        }
        else
        {
            Debug.Log("Cannot jump, not grounded"); // Debug log if not grounded
        }
    }
}
