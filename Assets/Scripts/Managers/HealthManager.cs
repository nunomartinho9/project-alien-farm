using System;
using UnityEngine.UI;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    [SerializeField] private FloatManagerSo floatManager;
    void Start()
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

    void Update()
    {
        
    }

    public void ChangeSliderValue(float amount)
    {
        hpSlider.value = amount;
    }
}
