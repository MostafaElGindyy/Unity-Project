using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentences : MonoBehaviour
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
                "Player: Hello",
                "Flower: Hi!"
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
