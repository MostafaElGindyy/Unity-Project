using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public int damageAmount = 50; // Damage amount
    private Animator animator; // Reference to the Animator component
    private bool hasExploded = false; // Prevent multiple triggers

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on the object.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasExploded && other.CompareTag("Player")) // Ensure it only triggers once
        {
            hasExploded = true; // Prevent further triggers

            // Apply damage to the player
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damageAmount);
            }

            // Play the explosion animation
            animator.SetTrigger("Explode");

            // Destroy the object after the animation
            StartCoroutine(DestroyAfterAnimation());
        }
    }

    IEnumerator DestroyAfterAnimation()
    {
        // Wait for the animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
