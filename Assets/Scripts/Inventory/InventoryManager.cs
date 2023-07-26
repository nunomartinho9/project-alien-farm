using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private int maxStackable = 16;
    [SerializeField] private InventorySlot[] inventorySlots;
    [SerializeField] private GameObject inventoryItemPrefab;

    private int selectedSlot = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void OnEnable()
    {
        UIInput2D.OnSlotSelect += ChangeSelectedSlot;
    }

    private void OnDisable()
    {
        UIInput2D.OnSlotSelect -= ChangeSelectedSlot;
    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0) inventorySlots[selectedSlot].Deselect();
        if (newValue >=4) return;        
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
        //Debug.Log("Changed slot");
    }
    public bool AddItem(Item item)
    {
        //check if any slot has the same item with count lower to max
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot thisSlot = inventorySlots[i];
            InventoryItem itemInSlot = thisSlot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.Item == item && itemInSlot.Count < maxStackable && itemInSlot.Item.stackable)
            {
                itemInSlot.Count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }
        
        //find any empty slot

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot thisSlot = inventorySlots[i];
            InventoryItem itemInSlot = thisSlot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, thisSlot);
                return true;
            }
        }

        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.IntializeItem(item);
    }

    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot.Item;
            if (use) itemInSlot.Count--;
            if (itemInSlot.Count <= 0)
            {
                Destroy(itemInSlot.gameObject);
            }
            else
            {
                itemInSlot.RefreshCount();
            }
            
            return item;
        }

        return null;
    }
}
