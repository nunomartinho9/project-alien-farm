using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IBreakable
{
    [SerializeField] private BreakableData data;
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private int startingLife = 3;
    private int life;
    private SpriteRenderer spriteRenderer;
    public BreakableData Data => data;

    private void Start()
    {
        life = startingLife;
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
            Destroy(gameObject);
        }
    }
}
