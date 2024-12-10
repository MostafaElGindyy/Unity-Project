using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerr : MonoBehaviour
{
    public GameObject CurrentCheckpoint;

    void Start()
    {
        CurrentCheckpoint = null;
    }

    void Update()
    {
    }

    public void RespawnPlayer()
    {
        FindObjectOfType<Player>().transform.position = CurrentCheckpoint.transform.position;
    }
}
