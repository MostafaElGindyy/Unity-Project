using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL1EnemyScene : MonoBehaviour
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

    "Now tell me! Where is my son!?",
    "Leo replies, “I don’t know and I never knew where your son is.",
     "Leo adds, I never agreed with Rico’s plan to kidnap your son ... but Jack should know where they took your boy.",
     "defeat me and ill willingly tell you"

            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
