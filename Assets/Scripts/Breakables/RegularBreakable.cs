using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RegularBreakable : MonoBehaviour, IBreakable
{
    [SerializeField] private BreakableData data;
    [SerializeField] private InventoryManager inventoryManager;
    private int life;
    private SpriteRenderer spriteRenderer;
    public BreakableData Data => data;

    private void Start()
    {
        life = Data.StartingLife;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Data.Sprite;
    }

    public void Damage()
    {
        Item selectedItem = inventoryManager.GetSelectedItem(false);
        if (selectedItem != Data.RequiredItem) return;
        life--;
        if (life <= 0)
        {
            Drop();
            Destroy(gameObject);
        }
    }

    public void Drop()
    {
        
        if (Data.DropLists.Length == 0) return;
        foreach (var drops in Data.DropLists)
        {
            for (int i = 1; i <= drops.Quantity; i++)
            {
                bool result = inventoryManager.AddItem(drops.Item);  
                if (result) Debug.Log("Item Added" + drops.Item);
                else Debug.Log("Item not added");
            }
        }

    }
}
