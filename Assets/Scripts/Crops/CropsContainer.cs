using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable Objects/Crops Container", fileName = "New Crops Container")]
public class CropsContainer : ScriptableObject
{
    
    
    public List<CropTile> crops;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

    public CropTile Get(Vector3Int position)
    {
        return crops.Find(x => x.position == position);
    }

    public void Add(CropTile cropTile)
    {
        crops.Add(cropTile);
    }

    public void Clear()
    {
        crops.Clear();
    }
}
