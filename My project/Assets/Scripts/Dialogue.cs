using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    private string[] dialogueSentences;
    private int index = 0;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject dialogueBox;

    // References to player and enemy Rigidbody2D components
    public Rigidbody2D player;
    public Rigidbody2D enemy;

    public IEnumerator TypeDialogue()
    {
        dialogueBox.SetActive(true);

        // Freeze player movement
        player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

        // Freeze enemy movement
        if (enemy != null)
        {
            enemy.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }

        foreach (char letter in dialogueSentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Enable the continue button after the entire sentence has been displayed
        continueButton.SetActive(true);
    }

    public void SetSentences(string[] sentences)
    {
        this.dialogueSentences = sentences;
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < dialogueSentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeDialogue());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            dialogueBox.SetActive(false);
            this.dialogueSentences = null;
            index = 0;

            // Unfreeze player movement
            player.constraints = RigidbodyConstraints2D.None;
            player.constraints = RigidbodyConstraints2D.FreezeRotation;

            // Unfreeze enemy movement
            if (enemy != null)
            {
                enemy.constraints = RigidbodyConstraints2D.None;
                enemy.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    void Start()
    {
        dialogueBox.SetActive(false);
        continueButton.SetActive(false);
    }
}
