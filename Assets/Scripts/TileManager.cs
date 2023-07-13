using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Item itemToUse;
    [SerializeField] private Tilemap interactableMap;

    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile interactedTile;

    public InventoryManager inventoryManager;
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeInteractableTilesHidden();
    }

    private void ChangeInteractableTilesHidden()
    {
        foreach (var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);
            if (tile != null && tile.name == "interact_visible")
            {
                interactableMap.SetTile(position, hiddenInteractableTile);
            }
        }        
    }

    public bool IsPlowable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);
        if (tile != null)
        {
            if (tile.name == "interact_hidden")
            {
                return true;
            }
        }

        return false;
    }

    public void SetInteracted(Vector3Int position)
    {
        Item selectedItem = inventoryManager.GetSelectedItem(false);
        if (selectedItem != itemToUse) return;
        Debug.Log("CAN PLOW IHI");
        interactableMap.SetTile(position, interactedTile);
    }

}
