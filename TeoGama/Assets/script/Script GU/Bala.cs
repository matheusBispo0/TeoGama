using UnityEngine;

public class Bala : MonoBehaviour
{
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Enemy"))
        {
            
            Destroy(gameObject);
        }
    }
}