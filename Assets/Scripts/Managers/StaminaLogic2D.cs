using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaLogic2D : MonoBehaviour
{
    private float value = 1f;
    [SerializeField] private FloatManagerSo stamina;
    private float time;
    [SerializeField] private float rechargeTime = 30f;
    

    private void Update()
    {
        DoCoolDown();
    }

    [ContextMenu("DecreaseStamina")]
    public void DecreaseStamina()
    {
        stamina.DecreaseValue(value);
    }
    
    public bool CheckCanCombat()
    {
        return stamina.Value > 0;
    }

    private void DoCoolDown()
    {
        if (stamina.Value < stamina.MaxValue)
        {
            time += Time.deltaTime;
            if (time >= rechargeTime)
            {
                stamina.IncreaseValue(value);
                time = 0;
            }
        }
    }

}
