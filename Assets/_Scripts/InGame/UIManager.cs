using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject keyIcon;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        keyIcon.SetActive(false);
    }

    public void ShowKeyIcon()
    {
        keyIcon.SetActive(true);
    }
}

