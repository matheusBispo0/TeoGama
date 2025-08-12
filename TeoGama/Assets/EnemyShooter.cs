using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float shootingRange = 10f;
    public float shootingCooldown = 2f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    private Transform player;
    private float nextFireTime;

    public void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

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
}