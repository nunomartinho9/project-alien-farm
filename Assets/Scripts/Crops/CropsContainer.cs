using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable Objects/Crops Container", fileName = "New Crops Container")]
public class CropsContainer : ScriptableObject
{
    
    public List<CropTile> crops;

    public CropTile Get(Vector3Int position)
    {
        return crops.Find(x => x.position == position);
        Debug.Log("97438921379812739812");
    }

    public void Add(CropTile cropTile)
    {
        crops.Add(cropTile);
        Debug.Log("Aaaaaaaaaaaaaaaaaaaaaaaaaaa");
    }

    public void Clear()
    {
        crops.Clear();
        Debug.Log("asdasdasdsadasdasdasda");
    }
}
