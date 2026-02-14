using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Mono.Cecil.Cil;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    //Game objects
        //highlights
    public GameObject Highlight;
    public GameObject EnemyHighlight;
        //Arrays
    public Characters[] allies;
    public Characters[] enemies;

    //Data types
    public int AllyIndex;               //holds the positions of the ally characters
    public int EnemyIndex;          //holds the positions of the enemy characters
    public bool isAttacking = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        positions = 0;
        enemypositions = 1;
        knight = AllyKnight.GetComponent<knight>();                 //Attaching the scripts into the Game Objects
        archer = AllyArcher.GetComponent<archer>();
        wizard = AllyWizard.GetComponent<wizard>();
        engineer = EnemyEngineer.GetComponent<engineer>();
        scientist = EnemyScientist.GetComponent<scientist>();
        warrior = EnemyWarrior.GetComponent<warrior>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        #region Highlight System
        if (isAttacking)
        {
            EnemySelection();
        }
        else
        {
            AllySelection();
        }
        //Player Highlight System
        /*
        if (isActive == true)
        {
            Highlight.SetActive(true);
        }
        else                                //Making the SetActive value be handle by a bool
        {
            Highlight.SetActive(false);
        }


        if (Keyboard.current.downArrowKey.wasPressedThisFrame && isAttacking == false)
        {
            isActive = true;
            if (isActive == true)
            {
                allyReady++;
                */
                /*
                for (int i = 0; i < SelectableCharacters.Count; i++ )
                {
                    
                    if (SelectableCharacters[i] == "Knight" && knight.attacked == false)
                    {
                        Selection.position = Knight.position;
                    }
                    else if (SelectableCharacters[i] == "Archer" && archer.attacked == false)
                    {
                        Selection.position = Archer.position;
                    }
                    else if (SelectableCharacters[i] == "Wizard" && wizard.attacked == false)
                    {
                        Selection.position = Wizard.position;
                    } 
                    print(i);
                }
                */
                /*
                positions++;
                if (positions > SelectableCharacters.Count - 1)
                {
                    positions = 0;
                }

                if (SelectableCharacters[positions] == "Knight" && knight.attacked == false)
                {
                    Selection.position = Knight.position;
                }
                else if (SelectableCharacters[positions] == "Archer" && archer.attacked == false)
                {
                    Selection.position = Archer.position;
                }
                else if (SelectableCharacters[positions] == "Wizard" && wizard.attacked == false)
                {
                    Selection.position = Wizard.position;
                }

                if (allyReady > 1)
                {
                    allyReady = 1;
                }
            }
        }

        if (Keyboard.current.upArrowKey.wasPressedThisFrame && isAttacking == false)
        {
            isActive = true;
            if (isActive == true)
            {
                allyReady++;
                positions--;
                if (positions < SelectableCharacters.Count - SelectableCharacters.Count)
                {
                    positions = 2;
                }
 

                if (SelectableCharacters[positions] == "Knight" && knight.attacked == false)
                {
                    Selection.position = Knight.position;
                }
                else if (SelectableCharacters[positions] == "Archer" && archer.attacked == false)
                {
                    Selection.position = Archer.position;
                }
                else if (SelectableCharacters[positions] == "Wizard" && wizard.attacked == false)
                {
                    Selection.position = Wizard.position;
                }

                if (allyReady > 1)
                {
                    allyReady = 1;
                }
            }
        }
        */


        /*
        if (Keyboard.current.downArrowKey.wasPressedThisFrame && isAttacking == false) //Highlight.activeSelf == false
        {
            isActive = true;
            if (isActive == true)
            {
                positions++;
                allyReady++;
            }
        } 

        if (Keyboard.current.upArrowKey.wasPressedThisFrame && isAttacking == false)
        {
            isActive = true; 
            if (isActive == true)
            {
                positions--;
                allyReady++;
            }
        }
        
        if (positions == 1 && knight.attacked == false)
        {
            Selection.position = Knight.position;
        }
        else if (positions == 2 && archer.attacked == false)
        {
            Selection.position = Archer.position;
        }
        else if (positions == 3 && wizard.attacked == false)
        {
            Selection.position = Wizard.position; 
        }
        else if (positions > 3)
        {
            positions = 1;
        }
        else if (positions < 1)
        {
            positions = 3; 
        }

        if (allyReady > 1)
        {
            allyReady = 1;
        }
        */
        /*
        //Enemy Higlight System
        if (isActiveEnemy == true)
        {
            EnemyHighlight.SetActive(true);
        }
        else
        {
            EnemyHighlight.SetActive(false);
        }

        if (positions == 1 && Keyboard.current.enterKey.wasPressedThisFrame && allyReady == 1)
        {
            isAttacking = true;
            if (isAttacking == true)
            {
                isActiveEnemy = true;
            }
        }

        if (positions == 2 && Keyboard.current.enterKey.wasPressedThisFrame && allyReady == 1)
        {
            isAttacking = true;
            if (isAttacking == true)
            {
                isActiveEnemy = true;
            }
        }

        if (positions == 3 && Keyboard.current.enterKey.wasPressedThisFrame && allyReady == 1)
        {
            isAttacking = true;
            if (isAttacking == true)
            {
                isActiveEnemy = true;
            }
        }
        

        if (Keyboard.current.downArrowKey.wasPressedThisFrame && isAttacking == true)
        {
            enemypositions++;
            enemyReady++;
        } 

        if (Keyboard.current.upArrowKey.wasPressedThisFrame && isAttacking == true)
        {
            enemypositions--;  
            enemyReady++; 
        }
        
        if (enemypositions == 1)
        {
            EnemySelection.position = Engineer.position;
        }
        else if (enemypositions == 2)
        {
            EnemySelection.position = Scientist.position;
        }
        else if (enemypositions == 3)
        {
            EnemySelection.position = Warrior.position; 
        }
        else if (enemypositions > 3)
        {
            enemypositions = 1;
        }
        else if (enemypositions < 1)
        {
            enemypositions = 3; 
        }

        if (enemyReady > 1)
        {
            enemyReady = 1;
        }
        #endregion


        #region Battle System
        if (isAttacking == true)
        {
            //Attacking knight
            if (positions == 1 && enemyReady == 1)
            {
                if (knight.attacked == false && Keyboard.current.enterKey.wasPressedThisFrame && enemypositions == 1)
                {
                    engineer.hp -= knight.damage;
                    knight.attacked = true;
                    attacks--;
                    Reset();
                }

                if (knight.attacked == false && Keyboard.current.enterKey.wasPressedThisFrame && enemypositions == 2)
                {
                    scientist.hp -= knight.damage;
                    knight.attacked = true;
                    attacks--;
                    Reset();
                }

                if (knight.attacked == false && Keyboard.current.enterKey.wasPressedThisFrame && enemypositions == 3)
                {
                    warrior.hp -= knight.damage;
                    knight.attacked = true;
                    attacks--;
                    Reset();
                }
            }

            //Attacking archer
            if (positions == 2 && enemyReady == 1)
            {
                if (archer.attacked == false && Keyboard.current.enterKey.wasPressedThisFrame && enemypositions == 1)
                {
                    engineer.hp -= archer.damage;
                    archer.attacked = true;
                    attacks--;
                    Reset();
                }

                if (archer.attacked == false && Keyboard.current.enterKey.wasPressedThisFrame && enemypositions == 2)
                {
                    scientist.hp -= archer.damage;
                    archer.attacked = true;
                    attacks--;
                    Reset();
                }

                if (archer.attacked == false && Keyboard.current.enterKey.wasPressedThisFrame && enemypositions == 3)
                {
                    warrior.hp -= archer.damage;
                    archer.attacked = true;
                    attacks--;
                    Reset();
                }
            }

            //Attacking wizard 
            if (positions == 3 && enemyReady == 1)
            {
                if (wizard.attacked == false && Keyboard.current.enterKey.wasPressedThisFrame && enemypositions == 1)
                {
                    engineer.hp -= wizard.damage;
                    wizard.attacked = true;
                    attacks--;
                    Reset();
                }

                if (wizard.attacked == false && Keyboard.current.enterKey.wasPressedThisFrame && enemypositions == 2)
                {
                    scientist.hp -= wizard.damage;
                    wizard.attacked = true;
                    attacks--;
                    Reset();
                }

                if (wizard.attacked == false && Keyboard.current.enterKey.wasPressedThisFrame && enemypositions == 3)
                {
                    warrior.hp -= wizard.damage;
                    wizard.attacked = true;
                    attacks--;
                    Reset();
                }
            }
        }
        */
        #endregion
    }

    public void Reset()
    {
        /*
        isActive = false;
        isActiveEnemy = false;
        isAttacking = false; 
        positions = 0;
        enemypositions = 1;
        enemyReady = 0;
        allyReady = 0;
        */
    }

    public void AllySelection()
    {
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
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
            isAttacking = true;
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

        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            Attack();
        }

        EnemyHighlight.transform.position = enemies[EnemyIndex].transform.position;
    }

    public void Attack()
    {
        Characters Attacker = allies[AllyIndex];
        Characters Target = enemies[EnemyIndex];

    }
}
