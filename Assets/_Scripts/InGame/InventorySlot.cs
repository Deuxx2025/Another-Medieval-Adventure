using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI stackText;

    public BattleItem item;
    public int quantity;

    public void SetItem(BattleItem CurrentItem)
    {
        item = CurrentItem;
        quantity = 1;

        icon.sprite = item.icon;
        UpdateStack();
    }

    public void AddItem()
    {
        quantity++;
        UpdateStack();
    }

    void UpdateStack()
    {
        if (quantity > 1)
            stackText.text = quantity.ToString();
        else
            stackText.text = "";
    }

    public bool IsSameItem(BattleItem CurrentItem)
    {
        return item == CurrentItem;
    }
}
