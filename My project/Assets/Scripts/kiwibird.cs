using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiwibird : EnemyController
{
    // FixedUpdate is called at a fixed interval
    void FixedUpdate()
    {
        if (this.isFacingright == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y); // Fixed Rigidbody2D capitalization
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y); // Fixed Rigidbody2D capitalization
        }
    }

    void OnTriggerEnter2D(Collider2D Collider) // Fixed method and type names capitalization
    {
        if (Collider.tag == "Wall")
        {
            flip(); // Assuming flip() is defined in EnemyController
        }
        else if (Collider.tag == "Enemy")
        {
            flip();
        }
        else if (Collider.tag == "Player")
        {
            FindObjectOfType<playerstate>().takedamage(damage);
            flip();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
