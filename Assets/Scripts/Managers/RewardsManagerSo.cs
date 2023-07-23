using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable Objects/Rewards Manager", fileName = "New Rewards Manager")]

public class RewardsManagerSo : ScriptableObject
{
    public float Seeds { get; private set; }
    public float PopulationGain { get; private set; }
    
    [NonSerialized] public UnityEvent<float> seedsChangeEvent;

    public void OnEnable()
    {
        Seeds = 0;
        PopulationGain = 0;
        if (seedsChangeEvent == null)
            seedsChangeEvent = new UnityEvent<float>();
    }
    
    public void IncreaseSeedCount(float f)
    {
        if (Seeds >= 0) Seeds += f;
        seedsChangeEvent?.Invoke(Seeds);
    }
    
    public void CallEvent()
    {
        seedsChangeEvent?.Invoke(Seeds);
    }
}