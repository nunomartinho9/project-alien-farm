using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCombat : MonoBehaviour
{
    [SerializeField] private StaminaLogic2D stamina;

    public void GoToCombat()
    {
        if (stamina.CheckCanCombat())
        {
            Debug.Log("Can combat");
            stamina.DecreaseStamina();
            //todo: CHANGE SCENE
        }
        else
        {
            Debug.Log("Cant combat now. Wait a little.");
        }
    }
}
