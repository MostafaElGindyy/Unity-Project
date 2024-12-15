using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed; // Speed of the bullet
    public float timeremaining; // Lifespan of the bullet
    public int damage; // Damage the bullet inflicts
    public static float cooldown = 0.5f; // Cooldown time between bullets, adjustable
    private static float lastShotTime = -0.5f; // Tracks the last shot time
    private bool hasHit; // Tracks whether the bullet has already hit something

    void Start()
    {
        Player player;
        player = FindObjectOfType<Player>();

        // Flip bullet direction based on player's scale
        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        // Enforce cooldown on bullet instantiation
        if (Time.time - lastShotTime < cooldown)
        {
            Destroy(this.gameObject); // Destroy the bullet if it's fired before cooldown ends
            return;
        }
        lastShotTime = Time.time;
    }

    void Update()
    {
        // Move the bullet
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

        // Destroy bullet after its lifetime ends
        if (timeremaining > 0)
        {
            timeremaining -= Time.deltaTime;
        }
        else if (timeremaining <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ensure the bullet processes collision only once
        if (hasHit) return;

        if (other.tag == "Enemy")
        {
            // Try to get the EnemyController script and apply damage
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage, this.gameObject);
            }
            hasHit = true; // Mark the bullet as having hit
            Destroy(this.gameObject); // Destroy the bullet after hitting the enemy
        }
        else if (other.tag == "Ground" || other.tag == "Wall")
        {
            hasHit = true; // Mark the bullet as having hit
            Destroy(this.gameObject);
        }
    }
}