using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private CropData cropData;
    [SerializeField] private ResourcesContainer resources;
    [SerializeField] private GameObject collectable;
    private GameObject collectableInfo;
    
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
        if (container.crops.Count == 0) return;
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
       // Vector2Int position = (Vector2Int)gridPosition;

        CropTile tile = container.Get(gridPosition);

        if (tile == null) return;
        
        if (tile.Complete)
        {
            if (tile.crop.CropDrops.Length == 0) return;

            resources.AddStarCrops(tile.crop.CropDrops[0].Quantity);
            GameObject go = Instantiate(collectable);
        
            collectableInfo = go.transform.GetChild(0).gameObject;
            collectableInfo.GetComponent<TMP_Text>().text = "+ " + tile.crop.CropDrops[0].Quantity + " Star/s";
            collectableInfo.GetComponent<TMP_Text>().color = new Color(0, 255, 0, 255);
            Destroy(go, 2f);
            tile.Harvested();
            VisualizeTile(tile);
            interactableMap.SetTile(tile.position, hiddenInteractableTile);
            container.crops.Remove(tile);
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
        if (!CanSeed(position, seededTile)) return;
        
        CropTile tile = container.Get(position);
        if (tile == null) return;
        
        
        resources.UseSeed();
        interactableMap.SetTile(position, seededTile);
        tile.crop = cropData;
    }

    private bool CanSeed(Vector3Int position, Tile seedTile)
    {
        TileBase tile = interactableMap.GetTile(position);
        if (tile != null)
        {
            return tile.name != seedTile.name && resources.Seeds > 0;
        }

        return false;
    }
    
    public bool IsPlowable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);
        if (tile == null) return false;
        return tile.name == hiddenInteractableTile.name;
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
