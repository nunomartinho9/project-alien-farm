using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TimeController TimeController { get; private set; }
    private InventoryManager InventoryManager { get; set; }
    [SerializeField] private List<Item> startingItems;
    #region Persistent Data

    [SerializeField] private ResourcesContainer resourcesContainer;
    [SerializeField] private CropsContainer cropsContainer;
    [SerializeField] private FloatManagerSo earthLife;
    [SerializeField] private FloatManagerSo stamina;
    [SerializeField] private PlaceableObjectsContainer buildings;
    [SerializeField] private PlaceableObjectsContainer breakables;
    [SerializeField] private RewardsManagerSo rewards;
    #endregion

    // Start is called before the first frame update
    private void Awake()
    {
        TimeController = GetComponent<TimeController>();
        InventoryManager = GetComponent<InventoryManager>();
        
    }

    private void Start()
    {
        //sceneTransition.SetActive(true);
        
        if (startingItems == null) return;
        foreach (Item i in startingItems)
        {
            InventoryManager.AddItem(i);
        }
        UpdateAllUi();
    }

    private void Update()
    {

        
    }

    public void ResetGame()
    {
        resourcesContainer.Reset();
        cropsContainer.Clear();
        earthLife.Reset();
        stamina.Reset();
        buildings.Clear();
        breakables.Clear();
        rewards.Reset();
    }


    private void UpdateAllUi()
    {
        resourcesContainer.CallEvent();
        earthLife.CallEvent();
        stamina.CallEvent();
    }
}
