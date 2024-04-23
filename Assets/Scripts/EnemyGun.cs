using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 2f;
    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            Vector3 shootingDirection = (playerTransform.position - firePoint.position).normalized;
            Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(shootingDirection));
        }
    }
}
