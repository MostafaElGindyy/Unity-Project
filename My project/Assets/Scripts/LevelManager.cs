using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;
    private Vector3 checkpointPosition; // Variable to store the checkpoint position

    void Start()
    {
        checkpointPosition = Vector3.zero; // Initialize to zero
    }

    void Update()
    {
        // You can add any update logic here if needed
    }

    public void SetCheckpoint(Vector3 position)
    {
        checkpointPosition = position; // Store the position of the checkpoint
        // Optionally, you can keep a reference to the checkpoint GameObject if needed
        CurrentCheckpoint = new GameObject("Checkpoint"); // Create a temporary GameObject for the checkpoint
        CurrentCheckpoint.transform.position = position; // Set the position to the checkpoint
    }

    public void RespawnPlayer(GameObject player)
    {
        if (CurrentCheckpoint != null)
        {
            FindObjectOfType<Player>().transform.position = CurrentCheckpoint.transform.position;
        }
    }

    /* public void RespawnEnemy()
    {
        // Ensure enemy is assigned in the Inspector
        Instantiate(enemy, transform.position, transform.rotation);
        Debug.Log("Enemy respawned"); // Debug log for respawning enemy
    } */
}