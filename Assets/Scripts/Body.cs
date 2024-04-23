using UnityEngine;
using UnityEngine.InputSystem;

public class Body : MonoBehaviour
{
    public delegate void BodyPickedUpAction();
    public static event BodyPickedUpAction OnBodyPickedUp;

    public float pickupRange = 2.0f; // Distance within which the player can pick up the body
    public Transform attachmentPoint; // Specific point on the player where the body should attach

    private Transform player; // Reference to the player's transform
    private PlayerInput playerInput;
    private InputAction pickUpAction;
    private InputAction dropAction;
    private bool isCarried = false; // Track if the body is currently being carried

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerInput = player.GetComponent<PlayerInput>();
        pickUpAction = playerInput.actions["PickUp"];
        dropAction = playerInput.actions["Drop"];
    }

    void OnEnable()
    {
        pickUpAction.performed += _ => AttemptPickup();
        dropAction.performed += _ => DropBody();
    }

    void OnDisable()
    {
        pickUpAction.performed -= _ => AttemptPickup();
        dropAction.performed -= _ => DropBody();
    }

    void AttemptPickup()
    {
        if (Vector3.Distance(player.position, transform.position) <= pickupRange && !isCarried)
        {
            PickUpBody();
        }
    }

    private void PickUpBody()
    {
        if (OnBodyPickedUp != null)
        {
            OnBodyPickedUp();
        }

        if (attachmentPoint != null)
        {
            transform.SetParent(attachmentPoint);
        }
        else
        {
            transform.SetParent(player);
        }
        transform.localPosition = Vector3.zero; // Position the body at the attachment point
        isCarried = true;
        GetComponent<Rigidbody>().isKinematic = true; // Disable physics while being carried
    }

    void DropBody()
    {
        if (isCarried)
        {
            transform.SetParent(null); // Detach the body from the player
            GetComponent<Rigidbody>().isKinematic = false; // Re-enable physics
            isCarried = false;
        }
    }
}
