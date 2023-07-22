using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stone : MonoBehaviour, IBreakable
{
    [SerializeField] private BreakableData data;
    private InventoryManager inventoryManager;
    [SerializeField] private ResourcesContainer resourcesContainer;
    private int life;
    private SpriteRenderer spriteRenderer;
    public BreakableData Data => data;

    private void Start()
    {
        life = Data.StartingLife;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Data.Sprite;

        inventoryManager = GameObject.FindWithTag("GameController").GetComponent<InventoryManager>();
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
        resourcesContainer.AddRocks(data.QuantityToDrop);
    }


}
