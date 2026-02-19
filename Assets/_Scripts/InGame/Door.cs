using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    // Assigning teleport point and new room confiner
    [SerializeField] private Transform teleportPoint;
    [SerializeField] private Collider2D newRoomConfiner;

    // Camera confiner
    private CinemachineConfiner2D confiner;

    private void Start()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>(); // Find camera confiner    
    }
    public bool CanInteract()
    {
        // Door is only interactable when the player has got a key
        PlayerInventory player = FindFirstObjectByType<PlayerInventory>();

        return player != null && player.hasKey;
    }

    public void Interact(PlayerInventory inventory)
    {
        // Stop if the player does not have a key
        if (!inventory.hasKey) return;

        // Change to Combat Scene if the player opens the door with a key
        SceneManager.LoadScene("Combat");
    }
}
