using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PlaceableObject
{
    public SpriteRenderer renderer;
    public Vector3Int position;
    public Quaternion rotation;

    internal void Collected()
    {
        renderer.gameObject.SetActive(false);
    }

}
[CreateAssetMenu(menuName = "Scriptable Objects/Placeable Object")]
public class PlaceableObjectsContainer : ScriptableObject
{
    public List<PlaceableObject> placeableObjects;

    public void Add(PlaceableObject placeableObject)
    {
        placeableObjects.Add(placeableObject);
    }

    public PlaceableObject Get(Vector3Int position)
    {
        return placeableObjects.Find(x => x.position == position);
    }
    
    
    public void Clear()
    {
        placeableObjects.Clear();
    }
    
}
