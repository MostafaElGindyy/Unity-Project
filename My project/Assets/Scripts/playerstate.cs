using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerstate : MonoBehaviour
{
    public int health = 6;
    public int lives = 3;
    private SpriteRenderer spriteRenderer; // Fixed type name to SpriteRenderer
    public bool isimmunity = false;
    private float immunitytime = 0f; // Fixed type to float
    private float immunituDuration = 1.5f; // Fixed type to float
    public int coninsCollected = 0;
    private float flickerTime = 0f; // Added flickerTime
    private float flickerDuration = 0.1f; // Added flickerDuration

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>(); // Fixed method name to GetComponent and type name
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isimmunity == true)
        {
            spriteRendererFunc(); // Changed method name to spriteRendererFunc to avoid conflict with spriteRenderer variable
            immunitytime += Time.deltaTime; // Fixed Time.deltaTime
            if (immunitytime >= immunituDuration)
            {
                this.isimmunity = false; // Fixed assignment operator
                this.spriteRenderer.enabled = true;
                Debug.Log("immunity has ended"); // Added semicolon
            }
        }
    }

    public void takedamage(int damage)
    {
        if (this.isimmunity == false)
        {
            this.health -= damage;
            if (this.health < 0) this.health = 0;
            if (this.lives > 0 && this.health == 0)
            {
                FindObjectOfType<LevelManagerr>().RespawnPlayer(); // Assumes LevelManagerr is defined elsewhere
                this.health = 6;
                this.lives--;
            }
            else if (this.lives == 0 && this.health == 0)
            {
                Debug.Log("gameover");
                Destroy(this.gameObject); // Fixed method name to Destroy
            }
        }
        PlayHitReaction();
    }

    void PlayHitReaction()
    {
        this.isimmunity = true;
        this.immunitytime = 0f;
    }

    void spriteRendererFunc() // Changed method name to spriteRendererFunc to avoid conflict with spriteRenderer variable
    {
        if (this.flickerTime < this.flickerDuration)
        {
            this.flickerTime += Time.deltaTime; // Fixed Time.deltaTime
        }
        else if (this.flickerTime >= this.flickerDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            this.flickerTime = 0;
        }
    }

    public void collectcoins(int coinvalue)
    {
        this.coninsCollected += coinvalue;
    }
}
