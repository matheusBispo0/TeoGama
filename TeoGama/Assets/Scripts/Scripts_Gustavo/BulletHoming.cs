using UnityEngine;

public class BulletHoming : MonoBehaviour
{
    public float speed = 6f;    
    public float homingTime = 1f;

    Rigidbody2D rb;
    Transform player;
    float homingTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        homingTimer = homingTime;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        if (homingTimer > 0f)
        {
            Vector2 dir = ((Vector2)player.position - (Vector2)transform.position).normalized;
            rb.linearVelocity = dir * speed;
            homingTimer -= Time.fixedDeltaTime;
        }
        
    }
}