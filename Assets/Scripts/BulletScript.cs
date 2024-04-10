using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject explosionEffectPrefab; // Assign a prefab for the explosion effect in the inspector

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) // Make sure your ground objects are on the "Ground" layer
        {
            if (explosionEffectPrefab != null)
            {
                GameObject effect = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, 2f); // Adjust time as needed for the effect's duration
            }

            Destroy(gameObject); // Destroy the bullet
        }
    }
}
