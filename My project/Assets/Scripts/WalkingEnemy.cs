using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : EnemyController
{
    void FixedUpdate()
    {
        if (this.isFacingright == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = 
            new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = 
            new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);

        }
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Wall")
        {
            Flip();
        }
        else if(collider.tag == "Enemy")
        {
            Flip();
        }
        else if(collider.tag == "Spike")
        {
            Flip();
        }
        else if(collider.tag == "Object")
        {
            Flip();
        }
        if (collider.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Flip();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}