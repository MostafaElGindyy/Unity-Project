using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    // Method to take damage
    public void TakeDamage(int damage)
    {
        Debug.Log($"Damage received: {damage}");  // Debug log to confirm damage value

        if (damage > 0)
        {
            health -= damage;
            Debug.Log($"Enemy took damage! Remaining health: {health}");
        }

        // If health goes below zero, implement death logic
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");  // Debug log to confirm death
        // Handle death logic (e.g., destroy enemy object)
        Destroy(gameObject);
    }
}
