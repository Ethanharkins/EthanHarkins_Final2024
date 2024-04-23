using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    public Rigidbody playerRigidbody;  // Assign this in the inspector
    public float knockbackForce = 500f;  // Adjust the force as needed

    // This method is public so it can be called by the UnityEvent in the GunScript
    public void ApplyKnockback()
    {
        if (playerRigidbody == null)
        {
            Debug.LogError("Player Rigidbody is not assigned!");
            return;
        }

        // Calculate force direction: negative of the forward vector
        Vector3 forceDirection = -transform.forward;
        // Apply an impulse force to the Rigidbody
        playerRigidbody.AddForce(forceDirection * knockbackForce, ForceMode.Impulse);
    }
}
