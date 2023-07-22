using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStatusUi : MonoBehaviour
{
    [SerializeField] private FloatManagerSo earthLifeManager;
    [SerializeField] private FloatManagerSo staminaManager;
    
    [SerializeField] private Image earthUI;
    [SerializeField] private TMP_Text earthPopu;
    [SerializeField] private Image stamina;
    [SerializeField] private float valueMultiplier = 1000000f;
    private void OnEnable()
    {
        earthLifeManager.floatChangeEvent.AddListener(UpdateEarthUI);
        staminaManager.floatChangeEvent.AddListener(UpdateStaminaUI);
    }


    private void OnDisable()
    {
        earthLifeManager.floatChangeEvent.RemoveListener(UpdateEarthUI);
        staminaManager.floatChangeEvent.RemoveListener(UpdateStaminaUI);
    }

    private void Start()
    {
        earthPopu.text = (earthLifeManager.Value * valueMultiplier).ToString("G30");
    }

    private void UpdateEarthUI(float life)
    {
        earthUI.fillAmount = (earthLifeManager.Value / earthLifeManager.MaxValue);
        earthPopu.text = (earthLifeManager.Value * valueMultiplier).ToString("G30");
    }
    
    private void UpdateStaminaUI(float val)
    {
        stamina.fillAmount = (staminaManager.Value / staminaManager.MaxValue);
    }
    
}
