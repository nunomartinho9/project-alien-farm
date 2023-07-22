using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu (menuName = "Scriptable Objects/Float Manager", fileName = "New Float Manager")]
public class FloatManagerSo : ScriptableObject
{
    
    public float Value
    {
        get;
        private set;
    }
    [SerializeField] private float maxValue;

    public float MaxValue => maxValue;

    [NonSerialized] public UnityEvent<float> floatChangeEvent;

    private void OnEnable()
    {
        //Value = maxValue;
        if (floatChangeEvent == null)
            floatChangeEvent = new UnityEvent<float>();
    }

    public void DecreaseValue(float v)
    {
        if (Value > 0) Value -= v;
        floatChangeEvent?.Invoke(Value);
    }
    
    public void IncreaseValue(float v)
    {
        if (Value < maxValue) Value += v;
        floatChangeEvent?.Invoke(Value);
    }

    public void CallEvent()
    {
        floatChangeEvent?.Invoke(Value);
    }

    public void Reset()
    {
        Value = maxValue;
    }

}
