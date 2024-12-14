using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isFacingright = false;
    public float maxSpeed = 2;
    public int damage = 6; // Damage dealt to the player
    public int health = 100; // Enemy's health
    // public AudioClip hitSound;

    public void Flip()
    {
        isFacingright = !isFacingright;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken; // Reduce health by the incoming damage
        Debug.Log("Enemy took damage: " + damageTaken + ", Remaining health: " + health);

        // Destroy the enemy if health is less than or equal to zero
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Apply damage to the player
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            // AudioManager.instance.RandomizeSfx(hitSound); // Optional sound effect
        }
    }

    void Start()
    {
    }

    void Update()
    {
    }
}