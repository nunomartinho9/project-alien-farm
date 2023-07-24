using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable Objects/Rewards Manager", fileName = "New Rewards Manager")]

public class RewardsManagerSo : ScriptableObject
{
    public float Seeds { get; private set; }

    [SerializeField] private float startingPopGain = 50f;
    [SerializeField] private float upgradePopGain = 15f;
    public float PopulationGain { get; private set; }
    
    [NonSerialized] public UnityEvent<float> seedsChangeEvent;

    public void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
        Seeds = 0;
        
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

    public void UpgradePopulationGain()
    {
        PopulationGain += upgradePopGain;
        Debug.Log("fui chamado");
    }

    public void Reset()
    {
        PopulationGain = startingPopGain;
    }
}
