using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public int damageAmount = 20; // Damage amount that can be controlled in the Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the colliding object has the "Player" tag
        {
            // Get the PlayerStats component from the player
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damageAmount); // Apply damage to the player
            }

            // Instantiate explosion effect
            Destroy(gameObject); // Destroy this game object
        }
    }
}