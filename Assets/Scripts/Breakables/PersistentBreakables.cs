using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PersistentBreakables : MonoBehaviour
{
    [SerializeField] private PlaceableObjectsContainer container;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (container.placeableObjects.Count <= 0)
        {
            GetAllBreakables();
        }
        else
        {
            DestroyInactiveBreakables();
        }
    }
    
       
    private void OnDestroy()
    {
        for (int i = 0; i < container.placeableObjects.Count; i++)
        {
            container.placeableObjects[i].renderer = null;
        }
    }

    private void DestroyInactiveBreakables()
    {
        foreach (Transform child in transform)
        {
            PlaceableObject po = container.Get(Vector3Int.FloorToInt(child.position));
            if (po == null)
            {
                Destroy(child.gameObject);
            }

        }
    }
    public void RemoveBreakable(Vector3Int position)
    {
        PlaceableObject po = container.Get(position);
        container.placeableObjects.Remove(po);
    }
    
    void GetAllBreakables()
    {

        foreach (Transform child in transform)
        {
            PlaceableObject po = new PlaceableObject();

            po.position = Vector3Int.FloorToInt(child.position);
            po.rotation = child.rotation;
            po.renderer = child.gameObject.GetComponent<SpriteRenderer>();
            container.Add(po);

            
        }
            
    }
}
