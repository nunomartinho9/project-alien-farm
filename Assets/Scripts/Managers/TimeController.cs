using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    // Start is called before the first frame update
    private List<TimeAgent> timeAgents;
    private float time;
    private const float PhaseLength = 900f; // 15minutes in seconds
    [SerializeField] private float timeScale = 60f;

    private void Awake()
    {
        timeAgents = new List<TimeAgent>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * timeScale;
        InvokeTimeAgents();
    }

    public void Subscribe(TimeAgent timeAgent)
    {
        timeAgents.Add(timeAgent);
    }
    
    public void Unsubscribe(TimeAgent timeAgent)
    {
        timeAgents.Remove(timeAgent);
    }

    private int oldPhase = 0;
    private void InvokeTimeAgents()
    {
        int currentPhase = (int)(time / PhaseLength);
        if (oldPhase == currentPhase) return;
        oldPhase = currentPhase;
        foreach (var t in timeAgents)
        {
            t.Invoke();
        }


    }
}
