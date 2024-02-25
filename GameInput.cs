using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;//event is a keyword to declare an event in a class.EventHandler is a delegate type defined by the .NET framework
    
    
    private PlayerInputActions playerInputActions;
    
    
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();//when working with Unity's new Input System, is crucial for making the input actions available to be used within your game. 

        playerInputActions.Player.Interact.performed += Interact_performed;
    }


    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this ,EventArgs.Empty);// <Invoke> for checking null and neglecting it
    }


    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
       
        
        inputVector = inputVector.normalized;

        return inputVector;
    }
}
