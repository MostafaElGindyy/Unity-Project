using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            var playerStats = FindObjectOfType<PlayerStats>();
            playerStats.coinsCollected += coinValue;
            playerStats.CheckForLifeIncrease(); // Check for life increase when coins are collected
            Destroy(this.gameObject);
        }
    }
}