using UnityEngine;

public class BulletHoming : MonoBehaviour
{
    public float speed = 6f;

    Rigidbody2D rb;
    Transform player;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;
    }

    public void FixedUpdate()
    {
        if (player == null) return;
        Vector2 dir = ((Vector2)player.position - (Vector2)transform.position).normalized;
        rb.linearVelocity = dir * speed;
    }
}
