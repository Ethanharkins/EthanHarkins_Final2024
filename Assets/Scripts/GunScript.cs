using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletForce = 20f;
    public float recoilForce = 2f;
    private CharacterController characterController;
    private Transform playerCamera;

    private void Start()
    {
        characterController = GetComponentInParent<CharacterController>();
        playerCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Replace "Fire1" with your actual input for shooting if different
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Apply force to the bullet
        bulletRb.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.Impulse);

        // Apply recoil/knockback to the player
        ApplyRecoil();
    }

    private void ApplyRecoil()
    {
        // Calculate the opposite direction of where the player is looking
        Vector3 recoilDirection = -playerCamera.forward * recoilForce;

        // Apply a force to the player in the opposite direction
        // We use SimpleMove here for demonstration, but you might need to adjust this to fit your character controller logic
        characterController.SimpleMove(recoilDirection);
    }
}
