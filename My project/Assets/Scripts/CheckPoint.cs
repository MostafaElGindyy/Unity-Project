using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Use CompareTag for better performance
        {
            LevelManager levelManager = FindObjectOfType<LevelManager>();
            levelManager.SetCheckpoint(transform.position); // Set the checkpoint position
            Destroy(gameObject, 0.2f); // Destroy the checkpoint after a short delay
        }
    }
}