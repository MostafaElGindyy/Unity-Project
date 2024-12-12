using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public int health = 100;

    // Method to take damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy took damage! Remaining health: " + health);
        
        // If health goes below zero, you can implement death logic
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle enemy death, e.g., destroy enemy or play death animation
        Destroy(gameObject);
    }
}
