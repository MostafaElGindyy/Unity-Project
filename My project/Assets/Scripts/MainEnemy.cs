using System.Collections;
using UnityEngine;

public class MainEnemy : MonoBehaviour
{
    public Animator animator;
    private bool isAttacking = false;
    private EnemyController enemyController;
    private float previousSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
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
        if (enemyController.isFacingright)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyController.maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemyController.maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
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
            collider.GetComponent<PlayerStats>().TakeDamage(enemyController.damage);
            isAttacking = true;
            animator.SetTrigger("Attack");
            animator.SetBool("IsRunning", false);
            previousSpeed = enemyController.maxSpeed;
            enemyController.maxSpeed = 0;
            StartCoroutine(WaitForAttackAnimation());
        }
    }

    void Flip()
    {
        enemyController.Flip();
    }

    private IEnumerator WaitForAttackAnimation()
    {
        float attackAnimationDuration = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(attackAnimationDuration);
        
        animator.SetBool("IsRunning", true);
        isAttacking = false;
        
        enemyController.maxSpeed = previousSpeed;
        
        Walk();
    }
}