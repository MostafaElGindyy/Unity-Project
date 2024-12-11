using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isFacingright = false;
    public float maxSpeed = 2;
    public int damage = 6;
    // public AudioClip hitSound;

    public void Flip()
    {
        isFacingright = !isFacingright;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // AudioManager.instance.RandomizeSfx(hitSound);
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
    }

    void Start()
    {
    }

    void Update()
    {
    }
}