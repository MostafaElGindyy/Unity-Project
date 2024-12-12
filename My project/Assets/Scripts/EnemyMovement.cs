using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // Speed of the enemy movement
    public float leftBoundary = -5f; // Left boundary where the enemy should turn around
    public float rightBoundary = 5f; // Right boundary where the enemy should turn around
    private bool movingRight = true; // Flag to track if the enemy is moving right

    private Rigidbody2D rb; // Reference to the enemy's Rigidbody2D
    public LayerMask groundLayer; // Layer to check for ground beneath the enemy
    private Animator animator; // Reference to the enemy's Animator component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Initialize the Rigidbody2D component
        animator = GetComponent<Animator>(); // Initialize the Animator component

        // Make sure the enemy starts in the correct direction based on its position
        if (transform.position.x > rightBoundary)
        {
            movingRight = false; // If it's beyond the right boundary, move left
        }
        else if (transform.position.x < leftBoundary)
        {
            movingRight = true; // If it's beyond the left boundary, move right
        }
    }

    void Update()
    {
        // Move the enemy left and right
        Move();

        // Check if the enemy is falling off the platform (no ground beneath them)
        CheckForFall();
    }

    void Move()
    {
        // If moving right, set velocity to move to the right
        if (movingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y); // Move right
            FlipSprite(true); // Flip the sprite to face right
            animator.SetBool("run", true); // Set animation to run
        }
        // If moving left, set velocity to move to the left
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y); // Move left
            FlipSprite(false); // Flip the sprite to face left
            animator.SetBool("run", true); // Set animation to run
        }

        // Flip direction when reaching the boundaries
        if (transform.position.x >= rightBoundary)
        {
            movingRight = false; // Change direction to left when the right boundary is reached
        }
        else if (transform.position.x <= leftBoundary)
        {
            movingRight = true; // Change direction to right when the left boundary is reached
        }
    }

    void CheckForFall()
    {
        // Check if there's ground beneath the enemy (using a raycast)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        // If there’s no ground, turn the enemy around
        if (hit.collider == null)
        {
            movingRight = !movingRight; // Flip direction if there's no ground beneath
        }
    }

    void FlipSprite(bool isMovingRight)
    {
        // Flip the enemy sprite based on the direction
        Vector3 scale = transform.localScale;
        if (isMovingRight && scale.x < 0 || !isMovingRight && scale.x > 0)
        {
            scale.x = -scale.x; // Flip the sprite horizontally
            transform.localScale = scale;
        }
    }
}
