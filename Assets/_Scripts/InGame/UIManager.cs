using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Items & Puzzle Objects")] //Items Icons settings
    [SerializeField] private GameObject keyIcon;

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
}

