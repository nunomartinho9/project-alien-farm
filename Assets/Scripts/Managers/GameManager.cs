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
    #endregion

    // Start is called before the first frame update
    private void Awake()
    {
        TimeController = GetComponent<TimeController>();
        InventoryManager = GetComponent<InventoryManager>();
        
        ResetGame(); //todo: remove from final version
    }

    private void Start()
    {
        if (startingItems == null) return;
        foreach (Item i in startingItems)
        {
            InventoryManager.AddItem(i);
        }
        ResetGame(); //todo: remove from final version
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
    }

}
