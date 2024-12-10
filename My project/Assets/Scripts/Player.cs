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

    public KeyCode Attack;
    public Transform firepoint;
    public GameObject bullet;

    public AudioClip jump1;
    public AudioClip jump2;


    void Start() {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Update() {

        anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", grounded);
        
        // Jump condition
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }

        // Move left
        else if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

        // Move right
        else if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

        else if (Input.GetKeyDown(Attack))
        {
            Shoot();
        }
        
        // Set speed back to zero if no move key is pressed by player
        /* else if (!Input.GetKey(L) && !Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        } */

    }
    // Jump function
    void Jump()
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            // To make Jump sound effect
            // AudioManager.instance.RandomizeSfx(jump1, jump2);
        }

    void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
}