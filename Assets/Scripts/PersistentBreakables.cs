using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentBreakables : MonoBehaviour
{
    [SerializeField] private PlaceableObjectsContainer container;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GetBreakables();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       
    private void OnDestroy()
    {
        for (int i = 0; i < container.placeableObjects.Count; i++)
        {
            container.placeableObjects[i].renderer = null;
        }
    }
    
    public void RemoveBreakable(Vector3Int position)
    {
        PlaceableObject po = container.Get(position);
        po.Collected();
        container.placeableObjects.Remove(po);
    }
    
    void GetBreakables()
    {
        foreach (Transform child in transform)
        {
            PlaceableObject po = new PlaceableObject();

            po.position = Vector3Int.FloorToInt(child.position);
            po.rotation = child.rotation;
            container.Add(po);
        }
            
    }
}
