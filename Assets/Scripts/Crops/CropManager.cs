using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

[Serializable]
public class CropTile
{
    public int growTimer;
    public int growStage = 0;
    public CropData crop;
    public SpriteRenderer renderer;
    public Vector3Int position;

    public bool Complete
    {
        get
        {
            if (crop == null) return false;
            return growTimer >= crop.timeToGrow;
        }
    }

    internal void Harvested()
    {
        growTimer = 0;
        growStage = 0;
        crop = null;
        renderer.gameObject.SetActive(false);
    }
}
public class CropManager : TimeAgent
{
    [SerializeField] private Item itemToUse;
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile plowedTile;
    [SerializeField] private Tile seededTile;
    [SerializeField] private GameObject cropSpritePrefab;
    private InventoryManager inventoryManager; //dependency
    [SerializeField] private CropsContainer container;
    
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = gameObject.GetComponent<InventoryManager>();
        ChangeInteractableTilesHidden();
        
        Init();
        onTimeTick += Tick;
        VisualizeMap();
    }

    private void OnDestroy()
    {
        for (int i = 0; i < container.crops.Count; i++)
        {
            container.crops[i].renderer = null;
        }
    }

    private void VisualizeMap()
    {
        for (int i = 0; i < container.crops.Count; i++)
        {
            VisualizeTile(container.crops[i]);
        }
    }

    void VisualizeTile(CropTile cropTile)
    {
        interactableMap.SetTile(cropTile.position, cropTile.crop != null ? seededTile : plowedTile);

        if (cropTile.renderer == null)
        {
            
            GameObject go = Instantiate(cropSpritePrefab);
            go.transform.position = interactableMap.CellToWorld(cropTile.position);
            //go.SetActive(false);
            cropTile.renderer = go.GetComponent<SpriteRenderer>();
        }

        bool growing = cropTile.crop != null && 
                       cropTile.growTimer >= cropTile.crop.growthStageTime[0];
        
        cropTile.renderer.gameObject.SetActive(growing);
        if (growing) 
            cropTile.renderer.sprite = cropTile.crop.sprites[cropTile.growStage-1];
        
    }

    public void GetGrownCrop(Vector3Int gridPosition)
    {
        Vector2Int position = (Vector2Int)gridPosition;

        CropTile tile = container.Get(gridPosition);

        if (tile == null) return;


        Debug.Log("entrei");
        if (tile.Complete)
        {
            Debug.Log("crop not null");
            if (tile.crop.CropDrops.Length == 0) return;
            foreach (var drop in tile.crop.CropDrops)
            {
                for (int i = 1; i <= drop.Quantity; i++)
                {
                    Debug.Log("drop: " + drop);
                    bool result = inventoryManager.AddItem(drop.Item);
                    if (result) Debug.Log("Item Added" + drop.Item);
                }
            }
            tile.Harvested();
            VisualizeTile(tile);
        }
    }

    private void Tick()
    {
        foreach (CropTile cropTile in container.crops)
        {
            if (cropTile.crop == null) continue;
            
            if (cropTile.Complete) continue;
            
            cropTile.growTimer++;

            if (cropTile.growTimer >= cropTile.crop.growthStageTime[cropTile.growStage])
            {
                cropTile.renderer.gameObject.SetActive(true);
                cropTile.renderer.sprite = cropTile.crop.sprites[cropTile.growStage];
                
                cropTile.growStage++;
            }
            
        }
    }

    public bool CheckIfPlowed(Vector3Int position)
    {
        return container.Get(position) != null;
    }

    public void Seed(Vector3Int position)
    {
        Item selectedItem = inventoryManager.GetSelectedItem(false);

        if (selectedItem == null) return;

        if (selectedItem.type != ItemType.Seed || 
            selectedItem.actionType != ActionType.Plant ||
            !CanSeed(position, seededTile)) return;
        
        CropTile tile = container.Get(position);
        if (tile == null) return;
        
        
        selectedItem = inventoryManager.GetSelectedItem(true);
        CropData cropToSeed = selectedItem.crop;


        interactableMap.SetTile(position, seededTile);
        tile.crop = cropToSeed;
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
        if (selectedItem != itemToUse || selectedItem == null) return;

        if (CheckIfPlowed(position)) return;
        CreatePlowedTile(position);
    }

    private void CreatePlowedTile(Vector3Int position)
    {
        CropTile cropTile = new CropTile();
        container.Add(cropTile);

        cropTile.position = position;
        
        VisualizeTile(cropTile);
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
