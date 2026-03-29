using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    // Objects on Inventory
    public bool hasKey = false;

    public List<InventorySlot> items = new List<InventorySlot>();

    public static PlayerInventory instance;

    [SerializeField] private InventorySlot slotPrefab;      // Arrastra el prefab aquí
    [SerializeField] private Transform itemsContainer;   // Panel padre en la UI

    public void AddItem(BattleItem item)
    {
        foreach (InventorySlot slot in items)
        {
            if (slot.IsSameItem(item)) 
            {
                slot.AddItem();
                return;
            }
        }

        InventorySlot newSlot = Instantiate(slotPrefab, itemsContainer);
        newSlot.SetItem(item);
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
