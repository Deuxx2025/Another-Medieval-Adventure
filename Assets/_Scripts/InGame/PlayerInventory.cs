using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Objects on Inventory
    public bool hasKey = false;

    // Show key icon when collected
    public void CollectKey()
    {
        hasKey = true;
        UIManager.Instance.ShowKeyIcon();
    }
}
