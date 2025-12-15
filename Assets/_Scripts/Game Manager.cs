using System.Numerics;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Transform Knight; 
    public Transform Wizard;
    public Transform Archer;
    public Transform Selection; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.downArrowKey.isPressed)
        {
            Selection.position = Wizard.position;
        }
    }
}
