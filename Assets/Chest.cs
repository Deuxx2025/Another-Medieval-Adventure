using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public Sprite closedSprite;
    public Sprite openedSprite;

    public bool containsKey = false;

    private bool isOpen = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedSprite; // start closed
    }

    public void Interact()
    {
        if (isOpen) return;

        isOpen = true;
        spriteRenderer.sprite = openedSprite; 
        if (containsKey )
        {
            PlayerInventory.hasKey = true;
            Debug.Log("You found a key!");
        }
    }
}
