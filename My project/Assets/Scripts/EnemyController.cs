using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isFacingright = false;
    public float maxSpeed = 2;
    public int damage = 6; // Damage dealt to the player
    public int health = 100; // Enemy's health
    private HashSet<GameObject> processedBullets = new HashSet<GameObject>(); // Track bullets that already inflicted damage
    public NavigationController navigationController;

    public void Flip()
    {
        isFacingright = !isFacingright;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    public void TakeDamage(int damageTaken, GameObject bullet)
    {
        if (processedBullets.Contains(bullet)) return; // Skip if damage from this bullet was already processed
        processedBullets.Add(bullet);

        health -= damageTaken; // Reduce health by the incoming damage
        Debug.Log("Enemy took damage: " + damageTaken + ", Remaining health: " + health);

        // Destroy the enemy if health is less than or equal to zero
        if (health <= 0)
        {
            Die(); // Call the Die method when the enemy's health reaches 0
        }
    }

    private void Die()
    {
        // Call GoToNextLevel method from NavigationController to load the next level
        if (navigationController != null)
        {
            navigationController.GoToNextLevel();
        }

        Destroy(this.gameObject); // Destroy the enemy GameObject
    }


    void Start()
    {
    }

    void Update()
    {
    }
}