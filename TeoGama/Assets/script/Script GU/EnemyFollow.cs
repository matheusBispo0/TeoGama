using UnityEngine;
public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float visionRange = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        
        if (distance <= visionRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, LayerMask.GetMask("Obstaculo"));

            if (hit.collider == null)
            {
                rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
            }
            else
            {
                Vector2 perp = Vector2.Perpendicular(direction).normalized;
                rb.MovePosition(rb.position + perp * speed * Time.fixedDeltaTime);
            }
        }
    }
}