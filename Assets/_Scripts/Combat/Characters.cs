using UnityEngine;

public class Characters : MonoBehaviour
{
    public CharacterData Data;
    public int CurrentHP;
    public int AttackDamge;
    public bool IsAlive;
    public HealthDisplay healthDisplay;
    public bool HasAttacked;
    public bool DesignatedHero;
    public bool skillActive;
    public bool hasUsedSkill;
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
        healthDisplay.UpdateHealth(CurrentHP);
    }
}
