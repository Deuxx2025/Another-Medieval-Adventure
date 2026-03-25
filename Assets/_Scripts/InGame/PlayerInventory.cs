using NUnit.Framework;
using TMPro.EditorUtilities;
using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    // Objects on Inventory
    public bool hasKey = false;

    public List<BattleItem> items = new List<BattleItem>();

    public void AddItem(BattleItem item)
    {
        items.Add(item);
        Debug.Log("Added item: " + item.itemName);
    }
    // Show key icon when collected
    public void CollectKey()
    {
        hasKey = true;
        UIManager.Instance.ShowKeyIcon();
    }
}
