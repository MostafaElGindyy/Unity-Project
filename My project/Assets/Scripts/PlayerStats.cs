using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 6; // Player's starting health, adjust as needed
    public int lives = 3;

    private float flickerTime = 0f;
    private float flickerDuration = 0.1f;

    private SpriteRenderer spriteRenderer;

    public bool isImmune = false;
    private float immunityTime = 0f;
    private float immunityDuration = 1.5f;
   
    public int coinsCollected = 0;

<<<<<<< HEAD
=======
    // public AudioClip GameOverSound;

>>>>>>> d37d36d24529ef979a3aaf918f55652c5696ae10
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDuration)
        {
            this.flickerTime += Time.deltaTime;
        }
        else if (this.flickerTime >= this.flickerDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            this.flickerTime = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        if (this.isImmune == false)
        {
            this.health -= damage;
            if (this.health < 0) this.health = 0;
            if (this.lives > 0 && this.health == 0)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 6; // Reset health after respawn
                this.lives--;
            }
            else if (this.lives == 0 && this.health == 0)
            {
<<<<<<< HEAD
                Debug.Log("Game over");
=======
               // AudioManager.instance.PlaySingle(GameOverSound);
                // AudioManager.instance.musicSource.Stop();
                Debug.Log("Gameover");
>>>>>>> d37d36d24529ef979a3aaf918f55652c5696ae10
                Destroy(this.gameObject);
            }
            Debug.Log("Player Health: " + this.health);
            Debug.Log("Player Lives: " + this.lives);
        }
        PlayHitReaction();
    }

    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }

    void Update()
    {
        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime += Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }
    }

    public void CollectCoins(int coinValue)
    {
<<<<<<< HEAD
        this.coinsCollected += coinValue;
        Debug.Log("Coins Collected: " + this.coinsCollected);
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        FindObjectOfType<LevelManager>().RespawnPlayer();
    }
}
=======
        this.coinsCollected = this.coinsCollected + coinvalue;
    }
}
>>>>>>> d37d36d24529ef979a3aaf918f55652c5696ae10
