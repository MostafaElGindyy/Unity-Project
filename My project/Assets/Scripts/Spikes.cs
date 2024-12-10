using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damageAmount = 25; // Damage dealt by spikes

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player has collided
        if (collision.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();

            if (playerStats != null && !playerStats.isImmune) // Check if the player is not immune
            {
                playerStats.TakeDamage(damageAmount);
            }
        }
    }
}