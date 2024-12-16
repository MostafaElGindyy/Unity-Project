using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private Animator anim;

    public KeyCode shoot;
    public Transform firepoint;
    public GameObject bullet;

    private bool isShooting = false;

    // Reference to the Dialogue script to check if dialogue is active
    public Dialogue dialogueScript;  // Ensure this is assigned in the Inspector

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Update()
    {
        // Prevent movement and shooting if dialogue is active
        if (dialogueScript != null && dialogueScript.isDialogueActive)
        {
            return;  // If dialogue is active, skip the rest of the Update logic (prevent movement and shooting)
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", grounded);

        // Jump condition
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }

        // Move left
        else if (Input.GetKey(L) && !isShooting)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

        // Move right
        else if (Input.GetKey(R) && !isShooting)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

        // Shooting condition
        else if (Input.GetKeyDown(shoot) && !isShooting)
        {
            Shoot();
        }
    }

    // Jump function
    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    // Shooting function
    void Shoot()
    {
        isShooting = true;

        // Trigger the shoot animation immediately
        anim.SetTrigger("Shoot");

        // Instantiate the bullet at the firepoint
        Instantiate(bullet, firepoint.position, firepoint.rotation);

        // Wait for the animation to end and return to idle
        // The transition from shoot to idle will happen automatically in the Animator after the shoot animation finishes.
        isShooting = false;
    }
}

