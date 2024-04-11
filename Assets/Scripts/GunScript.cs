using UnityEngine;
using UnityEngine.InputSystem;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletForce = 20f;
    private InputAction shootAction;
    public Rigidbody playerRigidbody; // Assign this in the inspector
    public float knockbackForce = 5f;

    private void Awake()
    {
        var playerInput = GetComponent<PlayerInput>();
        if (playerInput != null)
        {
            shootAction = playerInput.actions["Shoot"];
        }
    }

    private void OnEnable()
    {
        if (shootAction != null)
        {
            shootAction.performed += OnShootPerformed;
        }
    }

    private void OnDisable()
    {
        if (shootAction != null)
        {
            shootAction.performed -= OnShootPerformed;
        }
    }

    private void OnShootPerformed(InputAction.CallbackContext context)
    {
        Shoot(); // Make sure this method is correctly defined in this class
    }

    // This is the Shoot method that must exist in your GunScript for everything to work
    private void Shoot()
    {
        Debug.Log("Shoot called");
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        Debug.Log($"Bullet instantiated at {bullet.transform.position}, with useGravity = {bulletRb.useGravity}");

        if (bulletRb != null)
        {
            bulletRb.useGravity = false; // Explicitly disable gravity here as well
            bulletRb.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.Impulse);
            Debug.Log($"Adding force: {bulletSpawnPoint.forward * bulletForce}");
        }
        else
        {
            Debug.LogError("Bullet prefab is missing a Rigidbody component.");
        }

        // Knockback
        Vector3 knockbackDirection = -transform.forward;
        playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        if (PauseMenu.GameIsPaused)
        {
            Debug.Log("Game is paused - cannot shoot.");
            return; // Exit the method early
        }
    }


}
