using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Chest : MonoBehaviour, IInteractable
{
    //Chests List
    public static List<Chest> AllChests = new List<Chest>();

    // Opened & Closed Sprites
    public Sprite closedSprite;
    public Sprite openedSprite;

    // Booleans
    public bool containsKey = false;
    private bool isOpened = false;

    // Items
    public BattleItem itemInside;

    // Renderer
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        // Adding all chests
        AllChests.Add(this);
    }

    private void OnDestroy()
    {
        // Remove chests at the end
        AllChests.Remove(this);
    }

    public void ForceOpen()
    {
        // Stop if already opened
        if (isOpened) return;

        // Open on logic and visually
        isOpened = true;
        spriteRenderer.sprite = openedSprite;
    }

    void Start()
    {
        // Get the renderer and start with all chests closed
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedSprite;
    }

    public bool CanInteract()
    {
        // Can interact only if it was not opened before
        return !isOpened;
    }

    public void Interact(PlayerInventory inventory)
    {
        // Don't interact if the chest was already opened
        if (isOpened) return;

        isOpened = true;
        spriteRenderer.sprite = openedSprite;

        if (itemInside != null)
        {
            inventory.AddItem(itemInside);
        }
        if (containsKey) // If the opened chest contains a key
        {
            inventory.CollectKey(); // Add key to inventory
            UIManager.Instance.ShowMessage("You found a key!", true); // Success message
            
            // Open all other chests
            foreach (Chest chest in AllChests) 
            {
                if (chest != this & chest.itemInside == null)
                {
                    chest.ForceOpen();
                }
            }
        }
        else { // If the opened chest does not contain a key
            if (itemInside == null)
            {
                UIManager.Instance.ShowMessage("There is nothing in here!", false); // Failure message
            }
            else
            {
                UIManager.Instance.ShowMessage("You just found a " + itemInside.itemName +"!!!", true); // Failure message
            }
        }
    }
}
