using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject explosionEffectPrefab; // Assign this in the Inspector

    private void Start()
    {
        Destroy(gameObject, 5f); // Optional: safety to ensure bullets don't live forever
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Assuming explosionEffectPrefab is your particle effect GameObject
        GameObject effectInstance = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        Destroy(effectInstance, 1.8f); // Destroy the effect after 3 seconds

        Destroy(gameObject); // Destroy the bullet itself immediately
    }

}
