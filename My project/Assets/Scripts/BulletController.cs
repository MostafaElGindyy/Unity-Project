using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed; // Speed of the bullet
    public float timeremaining; // Lifespan of the bullet
    public int damage; // Damage the bullet inflicts

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
        if (other.tag == "Enemy")
        {
            // Try to get the EnemyController script and apply damage
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(this.gameObject); // Destroy the bullet after hitting the enemy
        }
    }
}