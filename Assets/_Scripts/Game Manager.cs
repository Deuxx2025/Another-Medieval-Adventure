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
    public Transform Knight;            
    public Transform Wizard;
    public Transform Archer;
    public Transform Selection; 
    public int positions; 
    public bool isActive = false; 
    public GameObject Highlight; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        positions = 1;
    }

    // Update is called once per frame
    void Update()
    {
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

        
    }
}
