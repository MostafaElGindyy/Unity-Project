using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        // Detect climbing input (W key for going up)
        vertical = 0f; // Reset vertical movement

        if (isLadder) // Only allow climbing if on a ladder
        {
            if (Input.GetKey(KeyCode.W)) // Detect W key press for climbing up
            {
                vertical = 1f; // Move up
                isClimbing = true;
            }
            else if (Input.GetKey(KeyCode.S)) // Detect S key press for climbing down
            {
                vertical = -1f; // Move down
                isClimbing = true;
            }
            else
            {
                isClimbing = false; // Stop climbing if no key is pressed
            }
        }

        // If the player is climbing, stop gravity and apply movement.
        if (isClimbing)
        {
            rb.gravityScale = 0f;
        }
        else
        {
            rb.gravityScale = 1f; // Restore gravity when not climbing
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed); // Move vertically
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true; // Player is on the ladder, can start climbing
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false; // Player left the ladder, stop climbing
            isClimbing = false; // Stop any climbing behavior
        }
    }
}
