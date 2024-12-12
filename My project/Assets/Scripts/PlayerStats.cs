using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int lives = 3;

    private float flickerTime = 0f;
    private float flickerDuration = 0.1f;

    private SpriteRenderer spriteRenderer;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;
   
    public int coinsCollected = 0;
    public int coinsNeededForLife = 10; // Number of coins needed to add a life

    // public AudioClip GameOverSound;

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

    public void CheckForLifeIncrease()
    {
        if (coinsCollected >= coinsNeededForLife)
        {
            lives++;
            coinsCollected -= coinsNeededForLife; // Reset coins after increasing life
            Debug.Log("Lives increased! Current lives: " + lives);
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
                FindObjectOfType<LevelManager>().RespawnPlayer(this.gameObject);
                this.health = 100;
                this.lives--;
            }
            else if (this.lives == 0 && this.health == 0)
            {
               // AudioManager.instance.PlaySingle(GameOverSound);
                // AudioManager.instance.musicSource.Stop();
                Debug.Log("Gameover");
                Destroy(this.gameObject);
            }
            Debug.Log("Player Health:" + this.health.ToString());
            Debug.Log("Player Lives:" + this.lives.ToString());
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
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
                // Debug.Log("Immunity has ended");
            }
        }
    }

    public void collectcoins(int coinvalue)
    {
        this.coinsCollected = this.coinsCollected + coinvalue;
    }
}