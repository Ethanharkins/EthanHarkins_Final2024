using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject explosionEffectPrefab;
    public float lifetime = 5f;

    private void Start()
    {
        // Destroy the bullet after a set lifetime to clean up
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision other)
    {
        // Instantiate explosion effect at the bullet's position and rotation
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }

        // Destroy the bullet to simulate it exploding
        Destroy(gameObject);
    }
}
