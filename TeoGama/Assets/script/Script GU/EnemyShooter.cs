using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform firePoint;         
    public GameObject bulletPrefab;     
    public float shootInterval = 2f;    
    public float bulletSpeed = 7f;

    private float timer;

    public void Update()
    {
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
        rb.linearVelocity = firePoint.right * bulletSpeed;
    }
}