using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletForce = 20f;
    public ParticleSystem muzzleFlashEffect; // Optional: for visual effects
    private StarterAssets.StarterAssetsInputs input;

    private void Start()
    {
        // Assumes the StarterAssetsInputs component is on the same GameObject as this script or a parent GameObject.
        input = GetComponentInParent<StarterAssets.StarterAssetsInputs>();
    }

    private void Update()
    {
        if (input.shoot)
        {
            Shoot();
            input.shoot = false; // Reset the shoot input if it's handled as a one-time trigger
        }
    }

    private void Shoot()
    {
        if (muzzleFlashEffect != null)
        {
            muzzleFlashEffect.Play(); // Play muzzle flash effect
        }

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.Impulse);
    }
}
