using UnityEngine;

public class Characters : MonoBehaviour
{
    public CharacterData Data;
    public int CurrentHP;
    public int AttackDamge;
    public bool IsAlive;
    public bool HasAttacked;
    public bool DesignatedHero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHP = Data.MaxHP;
        AttackDamge = Data.Attack;
        IsAlive = Data.Alive;
        HasAttacked = Data.Attacked;
        DesignatedHero = Data.DH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageCalculation (int damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0)
        {
            IsAlive = false;
        }
    }
}
