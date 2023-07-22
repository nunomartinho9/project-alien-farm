using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour//,  IDropHandler
{
    private Image image;
    [SerializeField] private Color selectedColor, notSelectedColor;

    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }
    public void Select()
    {
        Deselect();
        image.color = selectedColor;
    }

    public void Deselect()
    {
        image.color = notSelectedColor;
    }

    
    // public void OnDrop(PointerEventData eventData)
    // {
    //     GameObject dropped = eventData.pointerDrag;
    //     InventoryItem inventoryItem = dropped.GetComponent<InventoryItem>();
    //     inventoryItem.ParentAfterDrag = transform;
    // }
}
