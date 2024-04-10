using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletForce = 20f;
    public ParticleSystem muzzleFlashEffect;
    private Transform playerCamera;

    private void Start()
    {
        playerCamera = Camera.main.transform;
        // Adjust the gun's initial rotation to match the camera's if necessary
        transform.rotation = Quaternion.Euler(0, playerCamera.eulerAngles.y, 0);
    }

    private void Update()
    {
        // Align the gun correctly with the camera direction
        // This assumes the gun's forward vector points along the barrel
        transform.rotation = Quaternion.Euler(playerCamera.eulerAngles.x, playerCamera.eulerAngles.y, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (muzzleFlashEffect != null)
        {
            muzzleFlashEffect.Play();
        }

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        Vector3 shootDirection = playerCamera.forward;
        bulletRb.AddForce(shootDirection * bulletForce, ForceMode.Impulse);
    }
}
