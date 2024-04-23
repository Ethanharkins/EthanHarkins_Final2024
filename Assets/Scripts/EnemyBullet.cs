using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f; // The speed at which the bullet moves
    public float lifeTime = 5f; // How long the bullet exists before automatically destroying
    public GameObject explosionEffectPrefab; // Prefab for the explosion effect when the bullet is destroyed

    void Start()
    {
        Destroy(gameObject, lifeTime); // Automatically destroy the bullet after a certain time
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime; // Move the bullet forward each frame
    }

    // Use this if your bullet's collider is set to Trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ground"))
        {
            PlayExplosionEffect(); // Play explosion effect
            Destroy(gameObject); // Destroy the bullet
        }
    }

    // Use this if your bullet's collider is not set to Trigger
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            PlayExplosionEffect(); // Play explosion effect
            Destroy(gameObject); // Destroy the bullet
        }
    }

    void PlayExplosionEffect()
    {
        if (explosionEffectPrefab)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity); // Instantiate the explosion effect at the bullet's position
        }
    }
}