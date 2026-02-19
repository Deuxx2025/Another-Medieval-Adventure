using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectCombat", menuName = "CharacterData")]
public class CharacterData : ScriptableObject
{
    public string CharacterName;
    public int MaxHP;
    public int Attack;
    public bool Alive;
    public bool Attacked;
    public bool DH;
}
