using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject interactionIcon;

    private IInteractable currentInteractable;

    private void Start()
    {
        interactionIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable != null && interactable.CanInteract())
        {
            currentInteractable = interactable;
            interactionIcon.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable != null)
        {
            currentInteractable = null;
            interactionIcon.SetActive(false);
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && currentInteractable != null)
        {
            PlayerInventory inventory = GetComponent<PlayerInventory>();
            currentInteractable.Interact(inventory);

            if (!currentInteractable.CanInteract())
            {
                interactionIcon.SetActive(false);
            }
        }
    }

}