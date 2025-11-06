using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootInterval = 2f;
    public float bulletSpeed = 7f;
    public float maxShootDistance = 10f;

    private float timer;
    private Transform player;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;
    }

    public void Update()
    {
        if (player == null) return;

      
        float sqrDist = (player.position - transform.position).sqrMagnitude;
        if (sqrDist > maxShootDistance * maxShootDistance) return;

        timer += Time.deltaTime;
        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = firePoint.right * bulletSpeed;
    }
}