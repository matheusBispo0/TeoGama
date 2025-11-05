using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public Transform player;    
    public float speed = 2f;      
    public float chaseRange = 5f; 

    private bool facingRight = true;

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

       
        if (distance < chaseRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position,
            new Vector2(player.position.x, transform.position.y),
            speed * Time.deltaTime);

           
            if ((direction.x > 0 && !facingRight) || (direction.x < 0 && facingRight))
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

}