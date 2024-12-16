using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL4EnemyScene : MonoBehaviour
{
    public Dialogue dialogueManager;
    private bool dialogueTriggered = false; // Add a flag to track if dialogue has already been triggered

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !dialogueTriggered) // Check if dialogue hasn't been triggered yet
        {
            dialogueTriggered = true; // Set the flag to true
            string[] dialogue =
            {
                "After several brutal fights, finally Rico appears.",
            "Rico : “You were always too soft, Max.”",
            "Max does not respond and gets ready to fight his last fight",
          

    };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
}
}