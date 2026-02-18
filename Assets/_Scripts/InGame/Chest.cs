using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Chest : MonoBehaviour, IInteractable
{
    public static List<Chest> AllChests = new List<Chest>();

    public Sprite closedSprite;
    public Sprite openedSprite;

    public bool containsKey = false;

    private bool isOpened = false;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        AllChests.Add(this);
    }

    private void OnDestroy()
    {
        AllChests.Remove(this);
    }

    public void ForceOpen()
    {
        if (isOpened) return;

        isOpened = true;
        spriteRenderer.sprite = openedSprite;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedSprite; // start closed
    }

    public bool CanInteract()
    {
        return !isOpened;
    }

    public void Interact(PlayerInventory inventory)
    {
        if (isOpened) return;

        isOpened = true;
        spriteRenderer.sprite = openedSprite;

        if (containsKey)
        {
            inventory.CollectKey();

            foreach (Chest chest in AllChests)
            {
                if(chest != this)
                {
                    chest.ForceOpen();
                }
            }
            Debug.Log("You got a key!");
        }
    }
}
