using System;
using System.Collections.Generic;
using System.Numerics;
using Mono.Cecil.Cil;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    //Transforms
    public Transform Knight;            
    public Transform Wizard;
    public Transform Archer;
    public Transform Selection;
    public Transform EnemySelection; 


    //Game objects
    public GameObject Highlight;
    public GameObject EnemyHighlight; 


    //Data types
    public int positions;
    public int enemypositions; 
    public bool isActive = false; 
    public bool isAttacking = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        positions = 1;
    }

    // Update is called once per frame
    void Update()
    {
        #region Highlight System
        if (isActive == true)
        {
            Highlight.SetActive(true);
        }
        else
        {
            Highlight.SetActive(false);
        }

        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            isActive = true;
            if (isActive == true)
            {
                positions++;
            }
        } 

        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
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

        if (positions == 1 && Keyboard.current.enterKey.wasPressedThisFrame)
        {
            isAttacking = true;
        }
        #endregion
    }
}
