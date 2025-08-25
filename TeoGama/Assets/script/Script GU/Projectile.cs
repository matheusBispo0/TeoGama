using UnityEngine;

public class Projectile : MonoBehaviour

{

    public float lifetime;

    public float speed = 1f;

    public Transform target;

    public Rigidbody2D rb;

    public float shootingRange = 10f;

    public float shootingCooldown = 2f;

    public GameObject projectilePrefab;

    public Transform firePoint;

    public Transform player;

    public float nextFireTime;



    public void Start()

    {

        if (GameObject.FindGameObjectWithTag("Player") != null)

        {

            player = GameObject.FindGameObjectWithTag("Player").transform;

        }



        rb = GetComponent<Rigidbody2D>();

        Destroy(gameObject, lifetime);

    }

}