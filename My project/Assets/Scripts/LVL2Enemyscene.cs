using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL2Enemyscene : MonoBehaviour
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
                "Jack: I’m sorry, Max. I just followed Rico's orders",
                "Max: I don’t care about your apology. I want to know where is my son located!",
                "Jack: Vince planned it all. He’s the one you should be after",
                "Jack: I know the his lab's location. But, I won't tell you unsless you defeat me",
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
