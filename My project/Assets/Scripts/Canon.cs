using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform firePoint;     // Point where bullets are spawned
    public float fireInterval = 5f; // Time between shots
    public int health = 50;         // Health of the cannon
    private float fireTimer;        // Timer to control bullet firing
    private bool isDestroyed = false; // Flag to track if the cannon is destroyed

    void Start()
    {
        fireTimer = fireInterval; // Initialize the fire timer
    }

    void Update()
    {
        // If the cannon is destroyed, stop firing
        if (isDestroyed)
        {
            return; // Skip the firing logic if destroyed
        }

        // Handle bullet firing if health > 0
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0)
        {
            FireBullet();
            fireTimer = fireInterval; // Reset the fire timer
        }
    }

    public void TakeDamage(int damageTaken, GameObject bullet)
    {
        if (isDestroyed) return; // Prevent further damage if destroyed

        health -= damageTaken; // Reduce health by the incoming damage
        Debug.Log("Canon took damage: " + damageTaken + ", Remaining health: " + health);

        // If health reaches zero or below, destroy the cannon
        if (health <= 0)
        {
            DestroyCanon(); // Destroy the cannon object
        }
    }

    void FireBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Spawn the bullet at the firePoint's position and rotation
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    void DestroyCanon()
    {
        if (isDestroyed) return; // If already destroyed, do nothing

        // Mark as destroyed to prevent further firing
        isDestroyed = true;

        // Optionally add destruction effects like explosion animation or sound
        // Example: Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // Destroy the cannon object and remove it from the scene
        Destroy(gameObject);
        Debug.Log("Canon destroyed and removed from the scene!");
    }
}