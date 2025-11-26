using UnityEngine;

public class BossShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 1f; // tiro a cada 1 segundo
    public float bulletSpeed = 5f;

    private Transform player;
    private float nextFire = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        if (Time.time >= nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
      //  Vector2 dir = (player.position - transform.position).normalized;

       // GameObject b = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
       // b.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
    }
}
