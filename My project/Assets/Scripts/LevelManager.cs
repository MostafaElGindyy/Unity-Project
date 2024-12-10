using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;
    public Transform enemy;

    void Start()
    {
    }

    void Update()
    {
    }

    public void RespawnPlayer()
    {
        // Ensure CurrentCheckpoint is assigned in the Inspector
        FindObjectOfType<Player>().transform.position = CurrentCheckpoint.transform.position;
        Debug.Log("Player respawned at checkpoint"); // Debug log for respawning player
    }

    public void RespawnEnemy()
    {
        // Ensure enemy is assigned in the Inspector
        Instantiate(enemy, transform.position, transform.rotation);
        Debug.Log("Enemy respawned"); // Debug log for respawning enemy
    }
}