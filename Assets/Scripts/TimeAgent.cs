using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAgent : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    
    
    
    public Action onTimeTick;
    private void Start()
    {
        //subscribe to something??
       Init();
    }

    
    private void OnDestroy()
    {
        _gameManager.TimeController.Unsubscribe(this);
    }

    public void Init()
    {
        _gameManager.TimeController.Subscribe(this);
    }

    public void Invoke()
    {
        onTimeTick?.Invoke();
    }
}
