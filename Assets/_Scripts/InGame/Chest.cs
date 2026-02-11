using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public Sprite closedSprite;
    public Sprite openedSprite;

    public bool containsKey = false;

    private bool isOpened = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedSprite; // start closed
    }

    public void Interact()
    {
        if (isOpened) return;

        isOpened = true;
        spriteRenderer.sprite = openedSprite;

        if (containsKey)
        {
            Debug.Log("You got a key!");
        }
    }
}
