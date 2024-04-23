using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab to shoot
    public Transform bulletSpawnPoint; // The point from which bullets are instantiated
    public float bulletForce = 20f; // The force to apply to the bullet for shooting
    public Rigidbody playerRigidbody; // The player's Rigidbody, for applying knockback
    public float knockbackForce = 5f; // The amount of knockback force to apply to the player
    private InputAction shootAction; // The shoot action from the Input System
   
    public UnityEvent onShoot;
    private void Awake()
    {
        var playerInput = GetComponent<PlayerInput>(); // Assumes PlayerInput component is attached to the same GameObject
        if (playerInput != null)
        {
            shootAction = playerInput.actions["Shoot"]; // This must match the name of the shoot action in your Input Actions asset
        }
    }

    private void OnEnable()
    {
        if (shootAction != null)
        {
            shootAction.performed += OnShootPerformed; // Subscribe to the shoot action
        }
    }

    private void OnDisable()
    {
        if (shootAction != null)
        {
            shootAction.performed -= OnShootPerformed; // Unsubscribe from the shoot action
        }
    }

    private void OnShootPerformed(InputAction.CallbackContext context)
    {
        Shoot();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // Instantiate the bullet at the spawn point
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.Impulse); // Apply force to shoot the bullet forward
        onShoot.Invoke();
        // Apply knockback force to the player in the opposite direction
        if (playerRigidbody != null)
        {
            Vector3 knockbackDirection = -bulletSpawnPoint.forward; // Calculate knockback direction
            playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        }
    }
}
