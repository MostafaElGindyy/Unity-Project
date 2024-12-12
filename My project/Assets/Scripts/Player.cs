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

    void Start() {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Update() {
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(Spacebar) && grounded) {
            Jump();
        }

        // Player movement (left and right)
        if (Input.GetKey(L)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (transform.localScale.x > 0) {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        } else if (Input.GetKey(R)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (transform.localScale.x < 0) {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

        // Handle attack inputs and animations
        if (Input.GetKeyDown(Attack1)) {
            anim.SetTrigger("Attack1");
        } else if (Input.GetKeyDown(Attack2)) {
            anim.SetTrigger("Attack2");
        } else if (Input.GetKeyDown(Attack3)) {
            if (Time.time >= nextAttack3Time) {
                anim.SetTrigger("Attack3");
                nextAttack3Time = Time.time + attack3Cooldown;
            }
        }
    }

    void Jump() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    // This method is called during the Animation Event for applying damage
    public void ApplyDamage() {
        Debug.Log("Player's attack hit the enemy!");
    }

    // This method will be called when the player’s attack collides with an enemy
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            int damage = 0;

            // Determine which attack is active and assign damage
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1")) {
                damage = damageAttack1;
            } else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2")) {
                damage = damageAttack2;
            } else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3")) {
                damage = damageAttack3;
            }

            // Apply damage to the enemy
            if (damage > 0) {
                Enemy enemy = collision.GetComponent<Enemy>();
                if (enemy != null) {
                    enemy.TakeDamage(damage);
                    Debug.Log($"Enemy health after attack: {enemy.health}");
                }
            }
        }
    }
}
