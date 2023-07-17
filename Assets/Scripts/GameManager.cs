using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TimeController TimeController { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        TimeController = GetComponent<TimeController>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
