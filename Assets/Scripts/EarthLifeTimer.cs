using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EarthLifeTimer : MonoBehaviour
{

    [SerializeField] private FloatManagerSo lifeManager;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (lifeManager.Value > 0.0f)
        {
            //earthLife -= Time.deltaTime;
            
            lifeManager.DecreaseValue(Time.deltaTime);
        }

        if (lifeManager.Value <= 0)
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0f;
        }
    }
}
