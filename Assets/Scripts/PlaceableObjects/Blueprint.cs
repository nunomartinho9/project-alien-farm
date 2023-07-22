using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Blueprint : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private GameObject building;

    [SerializeField] private Tilemap targetTilemap;
    [SerializeField] private PlaceableObjectsContainer container;
    
    [SerializeField] private LayerMask whatIsBreakable;
    [SerializeField] private float interactRadius = 5f;
    private bool isColliding;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        targetTilemap = GameObject.Find("Grid").transform.GetChild(4).GetComponent<Tilemap>();
        
        VisualizeMap();
    }

    void Update()
    {
        CheckColliding();
        if (!targetTilemap)
        {
            Debug.LogWarning("Target tilemap null....");
            return;
        }
        var worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPoint.z = 0f;
        var tpos = targetTilemap.WorldToCell(worldPoint);
        transform.position = tpos;
        
        Place(tpos);

    }
    
    private void Place(Vector3Int postionOnGrid)
    {
      
        bool canbuild = CanBuild(postionOnGrid);
        if (Input.GetMouseButtonDown(0))
        {
            if (!canbuild) return;
            CreateBuildingTile(targetTilemap.WorldToCell(postionOnGrid), transform.rotation);
            Destroy(gameObject);
        }
    }
    
    private void OnDestroy()
    {
        for (int i = 0; i < container.placeableObjects.Count; i++)
        {
            container.placeableObjects[i].renderer = null;
        }
    }

    private void VisualizeMap()
    {
        for (int i = 0; i < container.placeableObjects.Count; i++)
        {
            VisualizeTile(container.placeableObjects[i]);
        }
    }
    
    private bool CanBuild(Vector3 pos)
    {
        
        var tpos = targetTilemap.WorldToCell(pos);

        // Try to get a tile from cell position
        var tile = targetTilemap.GetTile(tpos);
        if (tile && !isColliding)
        {
            spriteRenderer.color = new Color(0, 231, 255, 50);
            return true;
        }
        
        spriteRenderer.color = new Color(255, 0, 0, 50);
        return false;
    }

    void VisualizeTile(PlaceableObject placeableObject)
    {
        if (placeableObject.renderer == null)
        {
            GameObject go = Instantiate(building, placeableObject.position, placeableObject.rotation);
            placeableObject.renderer = go.gameObject.GetComponent<SpriteRenderer>();
        }
        
        placeableObject.renderer.gameObject.SetActive(true);

    }
    
    private void CreateBuildingTile(Vector3Int position, Quaternion rotation)
    {
        PlaceableObject po = new PlaceableObject();

        po.position = position;
        po.rotation = rotation;
        container.Add(po);

        VisualizeTile(po);
        // interactableMap.SetTile(position, plowedTile);
    }
    
    private void CheckColliding()
    {
        isColliding = Physics2D.OverlapCircle(transform.position, interactRadius, whatIsBreakable);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
