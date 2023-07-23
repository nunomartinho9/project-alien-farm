using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EarthLifeTimer : MonoBehaviour
{

    [SerializeField] private FloatManagerSo lifeManager;
    [SerializeField] private float decreaseCooldown = 0f;
    
    
    public float DecreaseCooldown
    {
        get => decreaseCooldown;
        set => decreaseCooldown = value;
    }
    
    private float timestamp;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void Start()
    {
        lifeManager.CallEvent();
        timestamp = Time.time + decreaseCooldown;
    }

    private void Update()
    {
        
        if (lifeManager.Value > 0.0f)
        {

            if (timestamp <= Time.time)
            {
                lifeManager.DecreaseValue(Time.deltaTime);
                timestamp = Time.time + decreaseCooldown;
            }
            
        }

        if (lifeManager.Value <= 0)
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0f;
            
        }

    }
    
    
}
