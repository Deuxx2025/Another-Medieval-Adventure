using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    //Game objects
        //highlights
    public GameObject Highlight;
    public GameObject EnemyHighlight;
        //Arrays
    public Characters[] allies;
    public Characters[] enemies;
    public Characters[] AttackingCharacters;

    //Data types
    public int AllyIndex;               //holds the index for the ally Array
    public int EnemyIndex;              //holds the index for the enemy Array
    public int RandomNumber;
    public bool isAttacking = false;    //Changes the battle state for the player's turn
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Highlight System
        if (isAttacking)
        {
            EnemyHighlight.SetActive(true);
            EnemySelection();
        }
        else
        {
            EnemyHighlight.SetActive(false);
            AllySelection();
        }

        
    }

    public void Reset()
    {
        
    }

    public void AllySelection()
    {
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            Highlight.SetActive(true);
            int lenght = allies.Length;
            for (int i = 0; i < lenght; i++)
            {
                AllyIndex = (AllyIndex + 1 + lenght) % lenght;
                if (allies[AllyIndex].IsAlive && !allies[AllyIndex].HasAttacked)
                {
                    break;
                }
            }
        }

        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            Highlight.SetActive(true);
            int lenght = allies.Length;
            for (int i = 0; i < lenght; i++)
            {
                AllyIndex = (AllyIndex - 1 + lenght) % lenght;
                if (allies[AllyIndex].IsAlive && !allies[AllyIndex].HasAttacked)
                {
                    break;
                }
            }
        }

        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {

            if (Highlight.activeSelf)
            {
                if (allies[AllyIndex].IsAlive && !allies[AllyIndex].HasAttacked)
                {
                    isAttacking = true;
                    allies[AllyIndex].HasAttacked = true;
                }
            }
            else
            {
                Highlight.SetActive(true);
            }

        }

        Highlight.transform.position = allies[AllyIndex].transform.position;
    }

    public void EnemySelection()
    {
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            
            int lenght = enemies.Length;
            for (int i = 0; i < lenght; i++)
            {
                EnemyIndex = (EnemyIndex + 1 + lenght) % lenght;
                if (enemies[EnemyIndex].IsAlive)
                {
                    break;
                }
            }
        }

        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            int lenght = enemies.Length;
            for (int i = 0; i < lenght; i++)
            {
                EnemyIndex = (EnemyIndex - 1 + lenght) % lenght;
                if (enemies[EnemyIndex].IsAlive)
                {
                    break;
                }
            }
        }

        #endregion

        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            AttackStorage();
        }

        EnemyHighlight.transform.position = enemies[EnemyIndex].transform.position;
    }

    public void AttackStorage()
    {
        Characters Attacker = allies[AllyIndex];
        Characters Target = enemies[EnemyIndex];
        
        for (int i = 0; i < AttackingCharacters.Length; i++)
        {
            if (AttackingCharacters[i] == null)
            {
                AttackingCharacters[i] = Attacker;
                break;
            }
        }

        for (int i = 0; i < AttackingCharacters.Length; i++)
        {
            if (AttackingCharacters[i] == null)
            {
                AttackingCharacters[i] = Target;
                break;
            }
        }

        /*
        for (int i = 0; i < AttackingCharacters.Length; i++)
        {
            if (AttackingCharacters[i] != null)
            {
                AttackingCharacters[i] = null;
                break;
            }
        }
        */

        if (!Attacker.IsAlive || !Target.IsAlive)
        {
            return;
        }

        //Target.DamageCalculation(Attacker.AttackDamge);

        isAttacking = false;

        int lenght = allies.Length;
            for (int i = 0; i < lenght; i++)
            {
                AllyIndex = (AllyIndex - 1 + lenght) % lenght;
                if (allies[AllyIndex].IsAlive)
                {
                    break;
                }
            }

        foreach (Characters ally in allies)
        {
            if (ally.IsAlive && !ally.HasAttacked)
            {
                return;
            }
        }

        //CoinFlip
        for (int i = 0; i < 2; i++)
        {
            int amount;
            amount = Random.Range(0,2);
            if (i == 0)
            {
                if (amount == 1)
                {
                    Target.DamageCalculation(Attacker.AttackDamge);
                }
            }
            else
            {
                if (amount == 1)
                {
                    Attacker.DamageCalculation(Target.AttackDamge);
                }
                        
            }
        }

        print(Attacker.CurrentHP);
        print(Target.CurrentHP);

        foreach (Characters ally in allies)
        {
            ally.HasAttacked = false;
        }

    }
}
