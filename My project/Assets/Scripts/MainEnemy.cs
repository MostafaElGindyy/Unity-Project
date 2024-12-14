using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemy : MonoBehaviour
{
    private Animator animator; // Reference to the Animator component
    private EnemyController enemyController; // Reference to the EnemyController script
    private Rigidbody2D rb; // Reference to Rigidbody2D
    private bool isAttacking = false; // Prevents multiple attacks during overlap

    void Start()
    {
        // Get references to the Animator, EnemyController, and Rigidbody2D components
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component is missing from Main Enemy!");
        }

        enemyController = GetComponent<EnemyController>();
        if (enemyController == null)
        {
            Debug.LogError("EnemyController script is missing from Main Enemy!");
        }

        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing from Main Enemy!");
        }
    }

    void FixedUpdate()
    {
        // Move the enemy only if it's not attacking
        if (!isAttacking)
        {
            if (enemyController.isFacingright)
            {
                rb.velocity = new Vector2(enemyController.maxSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-enemyController.maxSpeed, rb.velocity.y);
            }
        }
        else
        {
            // Stop movement while attacking
            rb.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Handle collisions with walls, enemies, spikes, and objects
        if (collider.tag == "Wall" || collider.tag == "Enemy" || collider.tag == "Spike" || collider.tag == "Object")
        {
            if (!isAttacking) // Flip only when not attacking
            {
                enemyController.Flip();
            }
        }

        // Handle collision with the player
        if (collider.tag == "Player" && !isAttacking)
        {
            // Mark the enemy as attacking to stop movement
            isAttacking = true;

            // Play the Attack animation
            animator.Play("Attack", 0, 0f);

            // Start the delayed damage coroutine
            StartCoroutine(DelayedDamage());
        }
    }

    IEnumerator DelayedDamage()
    {
        // Wait for 1 second (or any desired delay)
        yield return new WaitForSeconds(1f);

        // Apply damage to the player
        FindObjectOfType<PlayerStats>().TakeDamage(enemyController.damage);

        // Return to idle after the attack animation finishes
        animator.SetTrigger("Idle");

        // Allow walking again
        isAttacking = false;
    }
}