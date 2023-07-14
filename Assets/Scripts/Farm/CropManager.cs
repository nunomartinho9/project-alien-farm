using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;


public class CropTile
{
    public int growTimer;
    public int growStage = 0;
    public CropData crop;
    public SpriteRenderer renderer;
}
public class CropManager : TimeAgent
{
    [SerializeField] private Item itemToUse;
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile plowedTile;
    [SerializeField] private Tile seededTile;
    [SerializeField] private GameObject cropSpritePrefab;
    public InventoryManager inventoryManager;

    private Dictionary<Vector2Int, CropTile> crops;

    // Start is called before the first frame update
    void Start()
    {
        crops = new Dictionary<Vector2Int, CropTile>();
        ChangeInteractableTilesHidden();
        
        Init();
        onTimeTick += Tick;
    }

    private void Tick()
    {
        foreach (CropTile cropTile in crops.Values)
        {
            if (cropTile.crop == null) { continue; }
            
            cropTile.growTimer++;

            if (cropTile.growTimer >= cropTile.crop.growthStageTime[cropTile.growStage])
            {
                cropTile.renderer.gameObject.SetActive(true);
                cropTile.renderer.sprite = cropTile.crop.sprites[cropTile.growStage];
                
                cropTile.growStage++;
            }

            if (cropTile.growTimer >= cropTile.crop.timeToGrow)
            {
                cropTile.crop = null;
            }
        }
    }

    public bool CheckIfPlowed(Vector3Int position)
    {
        return crops.ContainsKey((Vector2Int)position);
    }

    public void Seed(Vector3Int position)
    {
        Item selectedItem = inventoryManager.GetSelectedItem(false);

        if (selectedItem == null) return;

        if (selectedItem.type != ItemType.Seed || !CanSeed(position, seededTile)) return;
        Debug.Log(CanSeed(position, seededTile));
        selectedItem = inventoryManager.GetSelectedItem(true);
        CropData cropToSeed = selectedItem.crop;
            
        interactableMap.SetTile(position, seededTile);

        crops[(Vector2Int)position].crop = cropToSeed;
    }

    private bool CanSeed(Vector3Int position, Tile seedTile)
    {
        TileBase tile = interactableMap.GetTile(position);
        if (tile != null)
        {
            return tile.name != seedTile.name;
        }

        return false;
    }
    
    public bool IsPlowable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);
        if (tile == null) return false;
        return tile.name == "interact_hidden";
    }

    public void Plow(Vector3Int position)
    {
        Item selectedItem = inventoryManager.GetSelectedItem(false);
        if (selectedItem != itemToUse) return;

        CropTile cropTile = new CropTile();
        crops.Add((Vector2Int)position, cropTile);

        GameObject go = Instantiate(cropSpritePrefab);
        go.transform.position = interactableMap.CellToWorld(position);
        go.SetActive(false);
        cropTile.renderer = go.GetComponent<SpriteRenderer>();
        
        interactableMap.SetTile(position, plowedTile);
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

}
