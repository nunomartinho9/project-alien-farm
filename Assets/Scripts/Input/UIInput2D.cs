using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInput2D : MonoBehaviour
{
    public static event Action<int> OnSlotSelect;
    
    public void OnSlotOne(InputAction.CallbackContext context )
    {
        OnSlotSelect?.Invoke(0);
        Debug.Log("Slot1");
    }
    
    public void OnSlotTwo(InputAction.CallbackContext context )
    {
        OnSlotSelect?.Invoke(1);
        Debug.Log("Slot2");
    }
    
    public void OnSlotThree(InputAction.CallbackContext context )
    {
        OnSlotSelect?.Invoke(2);
        Debug.Log("Slot3");
    }
    
    public void OnSlotFour(InputAction.CallbackContext context )
    {
        OnSlotSelect?.Invoke(3);
        Debug.Log("Slot4");
    }
    
    public void OnSlotFive(InputAction.CallbackContext context )
    {
        OnSlotSelect?.Invoke(4);
        Debug.Log("Slot5");
    }
    
    public void OnSlotSix(InputAction.CallbackContext context )
    {
        OnSlotSelect?.Invoke(5);
        Debug.Log("Slot6");
    }
}
