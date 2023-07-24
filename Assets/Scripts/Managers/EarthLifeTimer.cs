using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EarthLifeTimer : MonoBehaviour
{

    [SerializeField] private FloatManagerSo lifeManager;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void Start()
    {
        lifeManager.CallEvent();
    }

    private void Update()
    {
        
        if (lifeManager.Value > 0.0f)
        {
                lifeManager.DecreaseValue(Time.deltaTime);

        }

        if (lifeManager.Value <= 0)
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0f;
            
        }

    }
    
    
}
