using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EarthLifeTimer : MonoBehaviour
{

    [SerializeField] private FloatManagerSo lifeManager;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private SoundEffectSo gameoverSound;
    [SerializeField] private AudioSource bgmusic;
    private bool canChangeTime;
    private void Awake()
    {
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Start()
    {
        lifeManager.CallEvent();
        canChangeTime = true;
    }

    private void Update()
    {
        
        if (lifeManager.Value > 0.0f)
        {
                lifeManager.DecreaseValue(Time.deltaTime);

        }

        if (lifeManager.Value <= 0)
        {
            if (canChangeTime)
            {
                gameOverScreen.SetActive(true);
                gameoverSound.Play();
                bgmusic.Stop();
                Time.timeScale = 0f;
                canChangeTime = false;
            }
            
        }

    }
    
    
}
