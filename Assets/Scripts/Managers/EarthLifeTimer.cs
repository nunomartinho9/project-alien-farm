using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EarthLifeTimer : MonoBehaviour
{

    [SerializeField] private FloatManagerSo lifeManager;
    [SerializeField] private float decreaseCooldown = 0f;
    private float timestamp;
    private void Start()
    {
        Time.timeScale = 1f;
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
