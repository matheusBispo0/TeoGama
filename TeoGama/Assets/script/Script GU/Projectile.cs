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


    public void Update()
    {
        if (player == null)
            return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= shootingRange && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + shootingCooldown;
        }

        if (distanceToPlayer <= shootingRange && Time.time >= nextFireTime)
        {
            Shoot();

            nextFireTime = Time.time + shootingCooldown;
        }

        if (distanceToPlayer <= shootingRange && Time.time >= nextFireTime)
        {
            Shoot();

            nextFireTime = Time.time + shootingCooldown;
        }
    }

    public void Seek(Transform _target)
    {
        target = _target;
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);


        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.Seek(player);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}