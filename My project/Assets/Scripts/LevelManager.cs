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
        FindObjectOfType<Player>().transform.position = CurrentCheckpoint.transform.position;
    }

    // Used if Enemy respawning at a point is needed
    public void RespawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}