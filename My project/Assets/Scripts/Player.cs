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


    public float attack3Cooldown = 3f; // Cooldown time in seconds
    private float nextAttack3Time = 0f;  // Time when Attack3 can be used again

    // Damage values for each attack
    public int damageAttack1 = 20;
    public int damageAttack2 = 20;
    public int damageAttack3 = 50;
    

    // public AudioClip jump1;
    // public AudioClip jump2;


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
        
    else if (Input.GetKeyDown(Attack1))
    {
        anim.SetTrigger("Attack1");
    }

    // Trigger Attack2 Animation
    else if (Input.GetKeyDown(Attack2))
    {
        anim.SetTrigger("Attack2");
    }

    // Trigger Attack3 Animation
    else if (Input.GetKeyDown(Attack3))
        {
            if (Time.time >= nextAttack3Time) // Check if cooldown is over
            {
                anim.SetTrigger("Attack3");
                nextAttack3Time = Time.time + attack3Cooldown; // Reset cooldown timer
            }
            else
            {
                float remainingTime = nextAttack3Time - Time.time; // Calculate remaining cooldown time
                Debug.Log($"Attack3 is on cooldown! Remaining time: {remainingTime:F1} seconds");            }
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

         void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            int damage = 0;

            // Determine which attack is active and assign damage
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
            {
                damage = damageAttack1;
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
            {
                damage = damageAttack2;
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
            {
                damage = damageAttack3;
            }

            // Apply damage to the enemy
            if (damage > 0)
            {
                collision.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }
}