using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerr : MonoBehaviour
{
    public GameObject CurrentCheckpoint; // Ensure this is assigned in Inspector
    public Transform enemy;

    void Start()
    {
    }

    void Update()
    {
    }

    public void RespawnPlayer()
    {
        // Add a check to ensure CurrentCheckpoint is not null
        if (CurrentCheckpoint != null)
        {
            FindObjectOfType<Player>().transform.position = CurrentCheckpoint.transform.position;
            Debug.Log("Player respawned at checkpoint"); // Debug log for respawning player
        }
        else
        {
            Debug.LogError("CurrentCheckpoint is not assigned!"); // Error log if checkpoint is not assigned
        }
    }

    public void RespawnEnemy()
    {
        // Ensure enemy is assigned in the Inspector
        Instantiate(enemy, transform.position, transform.rotation);
        Debug.Log("Enemy respawned"); // Debug log for respawning enemy
    }
}
