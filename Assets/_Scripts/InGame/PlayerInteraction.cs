using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    // Interaction Icon (!)
    public GameObject interactionIcon;

    // Current Interactable close to the player
    private IInteractable currentInteractable;

    private void Start()
    {
        // Hide Interaction Icon from the beginning
        interactionIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect interactable on collision (it is on trigger but can be changed to be on collision)
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable != null && interactable.CanInteract()) // Only interact according to their definition
        {
            currentInteractable = interactable;
            interactionIcon.SetActive(true); // Activating icon
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable != null)
        {
            currentInteractable = null;
            interactionIcon.SetActive(false); // Stop showing icon when getting away
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && currentInteractable != null) // When 'E' is pressed on an interactable object
        {
            PlayerInventory inventory = GetComponent<PlayerInventory>(); // Check inventory
            currentInteractable.Interact(inventory); // Interact with inventory

            // Hide Interaction Icon when the object is not interactable
            if (!currentInteractable.CanInteract())
            {
                interactionIcon.SetActive(false);
            }
        }
    }

}