using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    InputSystem_Actions inputActions;

    [Header("Items & Puzzle Objects")] //Items Icons settings
    [SerializeField] private GameObject keyIcon;
    public GameObject inventoryPanel;
    public Transform itemsContainer;
    public GameObject itemPrefab;
    public PlayerInventory playerInventory;


    [Header("UI Text")] // Text settigns
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private float messageDuration = 2f;
    [SerializeField] Color successColor;
    [SerializeField] Color failureColor;

    private void Awake()
    {
        Instance = this; // Make it global
        messageText.gameObject.SetActive(false); // Disable text
        keyIcon.SetActive(false); // Disable Key Icon
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void ShowMessage(string message, bool isSuccess)
    {
        StopAllCoroutines(); // Stop Coroutines
        StartCoroutine(ShowMessageRoutine(message, isSuccess)); // Start Message Coroutine
    }

    private IEnumerator ShowMessageRoutine(string message, bool isSuccess)
    {
        messageText.text = message; // Get message
        messageText.color = isSuccess ? successColor : failureColor; // Define color by success
        messageText.gameObject.SetActive(true); // Enable Text Message

        yield return new WaitForSeconds(messageDuration); // Keep the message on screen this time

        messageText.gameObject.SetActive(false); // Disable message
    }
    public void ShowKeyIcon()
    {
        keyIcon.SetActive(true); // Enable Key Icon
    }

    private void Update()
    {
        if (inputActions.InGame.Inventory.IsPressed())
        {
            inventoryPanel.SetActive(true);
            RefreshInventory();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    void RefreshInventory()
    {
        foreach (Transform child in itemsContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (BattleItem item in playerInventory.items)
        {
            GameObject icon = Instantiate(itemPrefab, itemsContainer);

            UnityEngine.UI.Image img = icon.GetComponent<UnityEngine.UI.Image>();
            img.sprite = item.icon;
        }
    }

}

