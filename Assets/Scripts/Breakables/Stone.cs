using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Stone : MonoBehaviour, IBreakable
{
    [SerializeField] private BreakableData data;
    private InventoryManager inventoryManager;
    [SerializeField] private ResourcesContainer resourcesContainer;
    private int life;
    private SpriteRenderer spriteRenderer;
    private PersistentBreakables breakablesContainer;
    
    public BreakableData Data => data;

    private void Start()
    {
        life = Data.StartingLife;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Data.Sprite;

        inventoryManager = GameObject.FindWithTag("GameController").GetComponent<InventoryManager>();
        breakablesContainer = GameObject.Find("Breakables").GetComponent<PersistentBreakables>();
    }

    public void Damage()
    {
        Item selectedItem = inventoryManager.GetSelectedItem(false);
        if (selectedItem != Data.RequiredItem) return;
        life--;
        if (life <= 0)
        {
            Drop();
            breakablesContainer.RemoveBreakable(Vector3Int.FloorToInt(transform.position));
            Destroy(gameObject);
        }
    }

    public void Drop()
    {
        resourcesContainer.AddRocks(data.QuantityToDrop);
    }


}
