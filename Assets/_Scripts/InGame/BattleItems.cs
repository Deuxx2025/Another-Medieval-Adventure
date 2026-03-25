using UnityEngine;

[CreateAssetMenu(fileName = "BattleItems", menuName = "BattleItems")]
public class BattleItem : ScriptableObject
{
    public string itemName;
    public Sprite icon;

    public int attackModifier;
    public int healthModifier;
    public int luckModifier;
    
}
