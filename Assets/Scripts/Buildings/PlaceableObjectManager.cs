using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObjectManager : MonoBehaviour
{
    [SerializeField] private PlaceableObjectsContainer container;

    private void Start()
    {
        VisualizeMap();
    }


    private void VisualizeMap()
    {
        for (int i = 0; i < container.placeableObjects.Count; i++)
        {
            VisualizeTile(container.placeableObjects[i]);
        }
    }
    
    
    void VisualizeTile(PlaceableObject placeableObject)
    {
        if (placeableObject.renderer == null)
        {
            GameObject go = Instantiate(placeableObject.prefab, placeableObject.position, placeableObject.rotation);
            placeableObject.renderer = go.gameObject.GetComponent<SpriteRenderer>();
        }
        
        placeableObject.renderer.gameObject.SetActive(true);

    }
}
