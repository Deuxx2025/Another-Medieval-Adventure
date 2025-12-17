using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Mono.Cecil.Cil;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    //Transforms
        //allies
    public Transform Knight;            
    public Transform Wizard;
    public Transform Archer;
    public Transform Selection;
        //enemies
    public Transform Engineer;
    public Transform Scientist;
    public Transform Warrior;
    public Transform EnemySelection; 


    //Calling Scripts
        //player characters
    knight knight;
    archer archer;
    wizard wizard;
        //NPC enemies
    engineer engineer;
    scientist scientist;
    warrior warrior;


    //Game objects
        //highlights
    public GameObject Highlight;
    public GameObject EnemyHighlight;
        //player characters
    public GameObject AllyKnight;
    public GameObject AllyArcher;
    public GameObject AllyWizard;
        //NPC enemies
    public GameObject EnemyEngineer;
    public GameObject EnemyScientist;
    public GameObject EnemyWarrior;


    //Data types
    public int positions;
    public int enemypositions; 
    public int ready;
    public bool isActive = false; 
    public bool isActiveEnemy = false; 
    public bool isAttacking = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        positions = 0;
        enemypositions = 1;
        knight = AllyKnight.GetComponent<knight>();
        archer = AllyArcher.GetComponent<archer>();
        wizard = AllyWizard.GetComponent<wizard>();
        engineer = EnemyEngineer.GetComponent<engineer>();
        scientist = EnemyScientist.GetComponent<scientist>();
        warrior = EnemyWarrior.GetComponent<warrior>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Highlight System
        //Player Highlight System
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
                positions++;
            }
        } 

        if (Keyboard.current.upArrowKey.wasPressedThisFrame && isAttacking == false)
        {
            isActive = true; 
            if (isActive == true)
            {
                positions--;
            }
        }
        
        if (positions == 1)
        {
            Selection.position = Knight.position;
        }
        else if (positions == 2)
        {
            Selection.position = Archer.position;
        }
        else if (positions == 3)
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

        //Enemy Higlight System
        if (isActiveEnemy == true)
        {
            EnemyHighlight.SetActive(true);
        }
        else
        {
            EnemyHighlight.SetActive(false);
        }

        if (positions == 1 && Keyboard.current.enterKey.wasPressedThisFrame)
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
            ready++;
        } 

        if (Keyboard.current.upArrowKey.wasPressedThisFrame && isAttacking == true)
        {
            enemypositions--;  
            ready++; 
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

        if (ready > 1)
        {
            ready = 1;
        }
        #endregion


        #region Battle System
        if (isAttacking == true)
        {
            if (positions == 1 && ready == 1)
            {
                if (knight.attacked == false && Keyboard.current.enterKey.wasPressedThisFrame && enemypositions == 1)
                {
                    engineer.hp -= knight.damage;
                    knight.attacked = true;
                }
            }
        }
        #endregion
        print(engineer.hp);
    }
}
