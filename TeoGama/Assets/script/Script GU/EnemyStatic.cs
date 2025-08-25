using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyStatic : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float jumpForce = 7f;
    public float pauseTime = 2f;
    public float chaseTime = 5f; 
    public float visionRange = 6f; 
    public float obstacleCheckDistance = 0.6f;
    public Transform groundCheck;
    public float patrolSpeed = 2f;
    public float patrolDistance = 3f;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool canMove = true;
    private bool chasing = false;
    private Vector2 startPos;
    private int patrolDirection = 1;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        StartCoroutine(ChaseAndPause());
    }

    public void Update()
    {
        if (player == null || !canMove) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= visionRange)
        {
            chasing = true;
            ChasePlayer();
        }
        else
        {
            chasing = false;
            Patrol();
        }
    }

    public void ChasePlayer()
    {
        Vector2 direction = new Vector2(player.position.x - transform.position.x, 0f).normalized;
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * Mathf.Sign(direction.x), obstacleCheckDistance, LayerMask.GetMask("Ground"));
        if (hit.collider != null && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void Patrol()
    {
        rb.linearVelocity = new Vector2(patrolDirection * patrolSpeed, rb.linearVelocity.y);

        if (Mathf.Abs(transform.position.x - startPos.x) >= patrolDistance)
        {
            patrolDirection *= -1;
        }
    }

    private IEnumerator ChaseAndPause()
    {
        while (true)
        {
            canMove = true;
            yield return new WaitForSeconds(chaseTime);

            if (chasing)
            {
                canMove = false;
                rb.linearVelocity = Vector2.zero;
                yield return new WaitForSeconds(pauseTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}