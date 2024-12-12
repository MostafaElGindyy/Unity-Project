using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    // This method is used to apply damage to the enemy
    public void TakeDamage(int damage) {
        health -= damage;
        Debug.Log($"Enemy took {damage} damage! Remaining health: {health}");

        if (health <= 0) {
            Die();
        }
    }

    // This method is called when the enemy’s health reaches 0
    private void Die() {
        Debug.Log("Enemy defeated!");
        Destroy(gameObject); // Destroy the enemy object when health reaches 0
    }
}
