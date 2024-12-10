using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // Ensure the player GameObject has the tag "Player"
        {
            FindObjectOfType<LevelManager>().CurrentCheckpoint = this.gameObject;
            Debug.Log("Checkpoint set"); // Debug log for setting checkpoint
        }
    }
}
