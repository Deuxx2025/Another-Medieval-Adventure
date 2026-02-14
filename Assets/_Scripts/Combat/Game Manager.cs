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
    
    }

    // Update is called once per frame
    void Update()
    {
        #region Highlight System
        if (isAttacking)
        {
            EnemySelection();
            print("Como que cosas haces");
        }
        else
        {
            AllySelection();
            print("Como que me hago pendejo");
        }

        print(enemies[EnemyIndex].CurrentHP);
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
            if (allies[AllyIndex].IsAlive && !allies[AllyIndex].HasAttacked)
            {
                isAttacking = true;
                allies[AllyIndex].HasAttacked = true;
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

        if (!Attacker.IsAlive || !Target.IsAlive)
        {
            return;
        }

        Target.DamageCalculation(Attacker.AttackDamge);

        isAttacking = false;

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
}
