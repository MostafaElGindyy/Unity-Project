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
    public KeyCode Attack1;
    public KeyCode Attack2;
    public KeyCode Attack3;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private Animator anim;

<<<<<<< HEAD
    public KeyCode Return; // For shooting
    public Transform firepoint; // Shooting fire point
    public GameObject bullet; // Bullet prefab

    public AudioClip jump1; // Jump sound effect 1
    public AudioClip jump2; // Jump sound effect 2

    void Start()
    {
=======
    // public AudioClip jump1;
    // public AudioClip jump2;


    void Start() {
>>>>>>> d37d36d24529ef979a3aaf918f55652c5696ae10
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Update() {

<<<<<<< HEAD
        // Jump condition
        if (Input.GetKeyDown(spacebar) && grounded)
=======
        anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", grounded);
        
        // Jump condition
        if (Input.GetKeyDown(Spacebar) && grounded)
>>>>>>> d37d36d24529ef979a3aaf918f55652c5696ae10
        {
            Jump();
        }

<<<<<<< HEAD
        // Shoot condition
        if (Input.GetKeyDown(Return))
        {
            Shoot();
        }

        // Move left
        if (Input.GetKey(keyLeft))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = true;
        }

        // Move right
        if (Input.GetKey(keyRight))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = false;
=======
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
>>>>>>> d37d36d24529ef979a3aaf918f55652c5696ae10
        }

<<<<<<< HEAD
    // Jump function
    private void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
        Debug.Log("Jump executed"); // Debug log for jump execution
        AudioManager.instance.RandomizeSfx(jump1, jump2); // Play jump sound effect
    }

    // Shoot function
    private void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
=======
        
        // Set speed back to zero if no move key is pressed by player
        /* else if (!Input.GetKey(L) && !Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        } */

>>>>>>> d37d36d24529ef979a3aaf918f55652c5696ae10
    }
    // Jump function
    void Jump()
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            // To make Jump sound effect
            // AudioManager.instance.RandomizeSfx(jump1, jump2);
        }
}