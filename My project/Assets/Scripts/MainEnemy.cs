using System.Collections;
using UnityEngine;

public class MainEnemy : MonoBehaviour
{
    public Animator animator;
    public bool isFacingRight = false;
    public float maxSpeed = 2;
    public int damage = 6;
    public int health = 100;
    private bool isAttacking = false;
    private float previousSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!isAttacking)
        {
            Walk();
        }
    }

    void Walk()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (isFacingRight)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Wall") || collider.CompareTag("Enemy") || collider.CompareTag("Spike") || collider.CompareTag("Object"))
        {
            Flip();
        }

        if (collider.CompareTag("Player") && !isAttacking)
        {
            PlayerStats player = collider.GetComponent<PlayerStats>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }

            isAttacking = true;
            animator.SetTrigger("Attack");
            animator.SetBool("IsRunning", false);
            previousSpeed = maxSpeed;
            maxSpeed = 0;
            StartCoroutine(WaitForAttackAnimation());
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator WaitForAttackAnimation()
    {
        float attackAnimationDuration = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(attackAnimationDuration);

        animator.SetBool("IsRunning", true);
        isAttacking = false;
        maxSpeed = previousSpeed;
        Walk();
    }
}