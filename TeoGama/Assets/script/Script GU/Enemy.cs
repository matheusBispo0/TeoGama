using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;   
    public float moveSpeed = 3f; 
    public bool followOnYAxis = false;

    void Update()
    {
        if (player != null)
        {
            Vector2 direction;

            if (followOnYAxis)
            {
                direction = (player.position - transform.position).normalized;
            }
            else
            {
                direction = new Vector2(player.position.x - transform.position.x, 0f).normalized;
            }

            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        }
    }
}