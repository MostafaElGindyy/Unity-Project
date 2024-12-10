using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // Check if the colliding object has the tag "Player"
        {
            FindObjectOfType<LevelManagerr>().RespawnPlayer(); // Call the RespawnPlayer method from LevelManagerr
        }
    }
}
