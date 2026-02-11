using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject interactionIcon;

    private void Start()
    {
        interactionIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered the trigger");

        if (other.CompareTag("Interactable"))
        {
            Debug.Log("Interactable detected!");
            interactionIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {  
            interactionIcon.SetActive(false);
        }
    }
}
    
