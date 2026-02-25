using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    //Game objects
        //highlights
    public GameObject Highlight;
    public GameObject EnemyHighlight;
        //Arrays
    public Characters[] allies;                 //Array that contains all the player's characters
    public Characters[] enemies;                //Array that contains all the NPC enemies
    public Characters[] AttackingCharacters;    //Array that contains in pairs the attacking allies and defending enemies

    //Data types
    public int AllyIndex;               //holds the index for the ally Array
    public int EnemyIndex;              //holds the index for the enemy Array
    public bool isAttacking = false;    //Changes the battle state when the player is selecting and when its attacking
    public bool PlayersTurn = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calling the respective methods of the states
        //and also making the highlight of the enemy be dynamic  
        if (PlayersTurn == true)
        {
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
        else
        {
            EnemyCheck();
        }
    }

    //For future use (16/2/26)
    public void Reset()
    {
        
    }

    //Handles the dynamic highlight for the allies so that the player know which ally it's being selected 
    public void AllySelection()
    {
        #region Highlight System
        //When the player use the down arrow key it scrolls the allies array and activates the highlight for the allies
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            Highlight.SetActive(true);
            int lenght = allies.Length;
            for (int i = 0; i < lenght; i++)
            {
                //AllyIndex uses a modular approach so that the player can't go beyond the limits of the array preventing an overflow
                AllyIndex = (AllyIndex + 1 + lenght) % lenght;
                //This `if` ensures that when it finds a valid target it stays there until the player hits the down button again 
                if (allies[AllyIndex].IsAlive && !allies[AllyIndex].HasAttacked)
                {
                    break;
                }
            }
        }

        //When the player use the up arrow key it scrolls the allies array and activates the highlight for the allies
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            Highlight.SetActive(true);
            int lenght = allies.Length;
            for (int i = 0; i < lenght; i++)
            {
                //AllyIndex uses a modular approach so that the player can't go beyond the limits of the array preventing an overflow
                AllyIndex = (AllyIndex - 1 + lenght) % lenght;
                //This `if` ensures that when it finds a valid target it stays there until the player hits the up button again
                if (allies[AllyIndex].IsAlive && !allies[AllyIndex].HasAttacked)
                {
                    break;
                }
            }
        }

        //When the player hits the enter key the ally highlight activates and handles the change of state for the attacking
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            //Here it ensures that the player can't enter the attack selecting part without activating the highlight first
            if (Highlight.activeSelf)
            {
                //This is so that the selected ally can now switch the state and update that character status
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
        //Dynamically update the highlight positions depending on the selected ally
        Highlight.transform.position = allies[AllyIndex].transform.position;
    }

    //Handles the dynamic highlight for the enemies so that the player know which enemy it's being selected
    public void EnemySelection()
    {
        //When the player use the down arrow key it scrolls the enemies array and activates the highlight for the enemies
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

        //When the player use the up arrow key it scrolls the enemies array and activates the highlight for the enemies
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
        //When the player hits the enter key it calls the method that handles the attacks and damage calculation
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            AttackStorage();
        }
        //Dynamically update the highlight positions depending on the selected enemy
        EnemyHighlight.transform.position = enemies[EnemyIndex].transform.position;
    }
    #region Battle Logic
    public void AttackStorage()
    {
        if (PlayersTurn == true)
        {
            if (!allies[AllyIndex].IsAlive || !enemies[EnemyIndex].IsAlive)
            {
                return;
            }
            isAttacking = false;
            //These two for loops indexes the attacker and defender in the AttackingCharacters Array
            for (int i = 0; i < AttackingCharacters.Length; i++)
            {
                //When it detects that the index is empty then it receive the current ally and enemy
                if (AttackingCharacters[i] == null)
                {
                    AttackingCharacters[i] = allies[AllyIndex];
                    break;
                }
            }

            for (int i = 0; i < AttackingCharacters.Length; i++)
            {
                if (AttackingCharacters[i] == null)
                {
                    AttackingCharacters[i] = enemies[EnemyIndex];
                    break;
                }
            }

            //Target.DamageCalculation(Attacker.AttackDamge);
    
            for (int i = 0; i < allies.Length; i++)
            {
                //AllyIndex uses a modular approach so that the player can't go beyond the limits of the array preventing an overflow
                AllyIndex = (AllyIndex + 1 + allies.Length) % allies.Length;
                //This `if` ensures that when it finds a valid target it stays there until the player hits the down button again 
                if (allies[AllyIndex].IsAlive && !allies[AllyIndex].HasAttacked)
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

            for (int i = 0; i < AttackingCharacters.Length/2 ; i++) // iterate in each of our allies (0,1,2)
            {
                //We accessed the Scriptable Object called Characters with Attacker and Target variables
                //Those variables receive the current index of the array
                Characters Attacker = AttackingCharacters[i*2]; // 0,2,4
                Characters Target = AttackingCharacters[i*2+1]; // 1,3,5

                //CoinFlip
                //This `for` increments a value from 0 to 1 
                for (int j = 0; j < 2; j++) // "j" represents the calculation of i=0: Ally to Enemy; i=1: Enemy to Ally
                {
                    //Then it generates a random number from 0 to 1 and it stores it in amount
                    int amount;
                    amount = Random.Range(0, 2);
                    //When the incremet hits 0 it runs the following code
                    if (j == 0)
                    {
                        //When the amount is 1 then Target receive damage
                        //and we send the Attacker's damage as a parameter to the DamageCalculation method in the Characters script
                        if (amount == 1)
                        {
                            Target.DamageCalculation(Attacker.AttackDamge);
                        }
                    }
                    else
                    {
                        //This does the exact same thing but backwards because this increment and amount value corresponds to the enemy
                        if (amount == 1)
                        {
                            Attacker.DamageCalculation(Target.AttackDamge);
                        }

                    }
                    //With this we get to generate randomly two numbers simultaneously and assign behaviours to it
                }
            }

            foreach (Characters ally in allies)
            {
                if (ally.HasAttacked)
                {
                    // PlayersTurn = false;
                    ally.HasAttacked = false;
                }
            }

            for (int i = 0; i < AttackingCharacters.Length; i++)
            {
                AttackingCharacters[i] = null;
            }
        }
        else
        {
            int Randomize;
            Randomize = Random.Range(0,3);
            Characters Attacker = enemies[Randomize];
            Characters Target = allies[Randomize];

            if (Attacker.IsAlive && !Attacker.HasAttacked)
            {
                
            }
        }
        

        //This is a type of reset because when the previous check doesn't run here it gives all the allies the ability to attack
        foreach (Characters ally in allies)
        {
            ally.HasAttacked = false;
        }

    }
    #endregion

    public void EnemyCheck()
    {
        foreach (Characters enemy in enemies)
        {
            if (enemy.IsAlive && !enemy.HasAttacked)
            {
                AttackStorage();
            }
        }
    }
}
