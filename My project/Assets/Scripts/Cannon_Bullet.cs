using UnityEngine;

public class Cannon_Bullet : MonoBehaviour
{
    public float speed = 5f;        // Speed of the bullet
    public float lifetime = 5f;    // Time before the bullet is destroyed
    public int damage = 20;        // Amount of damage the bullet deals

    void Start()
    {
        // Destroy the bullet after a certain time to avoid clutter
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object is the Player
        if (collision.CompareTag("Player"))
        {
            // Get the PlayerStats component from the player
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                // Damage the player
                playerStats.TakeDamage(damage);
            }

            // Destroy the bullet after hitting the player
            Destroy(gameObject);
        }
        if (collision.CompareTag("Ground"))
        {
                Destroy(gameObject);

        }
    }
}
