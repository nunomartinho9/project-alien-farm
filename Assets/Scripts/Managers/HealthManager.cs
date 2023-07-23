using System;
using UnityEngine.UI;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    [SerializeField] private FloatManagerSo floatManager;
    private void Start()
    {
        floatManager.Reset();
        ChangeSliderValue(floatManager.Value);
    }

    private void OnEnable()
    {
        floatManager.floatChangeEvent.AddListener(ChangeSliderValue);
    }
    
    private void OnDisable()
    {
        floatManager.floatChangeEvent.RemoveListener(ChangeSliderValue);
    }

    public void ChangeSliderValue(float amount)
    {
        hpSlider.value = amount;
    }
}
