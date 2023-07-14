using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TimeController TimeController { get; private set; }
    public CropManager CropManager { get; private set; }
    
    public InventoryManager InventoryManager { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        TimeController = GetComponent<TimeController>();
        CropManager = GetComponent<CropManager>();
        InventoryManager = GetComponent<InventoryManager>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
