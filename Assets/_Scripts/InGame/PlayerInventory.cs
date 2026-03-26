using NUnit.Framework;
using TMPro.EditorUtilities;
using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    // Objects on Inventory
    public bool hasKey = false;

    public List<InventorySlot> items = new List<InventorySlot>();

    public static PlayerInventory instance;
    public void AddItem(BattleItem item)
    {
        foreach (InventorySlot slot in items)
        {
            if (slot.item == item)
            {
                slot.quantity++;
                return;
            }
        }

        InventorySlot newSlot = new InventorySlot { item = item, quantity = 1 };
        items.Add(newSlot);

        Debug.Log("Slot item:" + newSlot.item);
    }
    // Show key icon when collected
    public void CollectKey()
    {
        hasKey = true;
        UIManager.Instance.ShowKeyIcon();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
