using UnityEngine;
using Unity.Cinemachine;
using UnityEditorInternal;
using UnityEngine.InputSystem.iOS;
using System.Runtime.CompilerServices;

public class Door : MonoBehaviour, IInteractable
{

    [SerializeField] private Transform teleportPoint;
    [SerializeField] private Collider2D newRoomConfiner;

    private CinemachineConfiner2D confiner;

    private void Start()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();    
    }
    public bool CanInteract()
    {
        PlayerInventory player = FindFirstObjectByType<PlayerInventory>();

        return player != null && player.hasKey;
    }

    public void Interact(PlayerInventory inventory)
    {
        if (!inventory.hasKey) return;

        Rigidbody2D rb = inventory.GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.zero;
        rb.position = teleportPoint.position;
        
        confiner.BoundingShape2D = newRoomConfiner;
        confiner.InvalidateBoundingShapeCache();

        Debug.Log("Teleported!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with:" + collision.gameObject.name);
    }

}
