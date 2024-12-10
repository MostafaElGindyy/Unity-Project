using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Water : MonoBehaviour
{
    public int damage = 1; // The amount of damage to deal when the player hits the spikes

    void Start()
    {
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Call the TakeDamage function from PlayerStats on the player object
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage); // Pass damage amount to the TakeDamage method
            }
        }
    }
}
