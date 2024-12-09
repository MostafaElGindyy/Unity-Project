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
        if (other.tag == "Player") // Fix this to match the tag in your player
        {
            FindObjectOfType<LevelManagerr>().CurrentCheckpoint = this.gameObject;
        }
    }
}
