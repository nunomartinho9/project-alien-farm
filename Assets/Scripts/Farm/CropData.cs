using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu (menuName = "Scriptable Objects/Crop Data", fileName = "New Crop Data")]
public class CropData : ScriptableObject
{
    
    [SerializeField] private Item seedItem;
    public Item SeedItem => seedItem;

    public int timeToGrow = 10;
    public int count = 1;

    public List<Sprite> sprites;
    public List<int> growthStageTime;
}
