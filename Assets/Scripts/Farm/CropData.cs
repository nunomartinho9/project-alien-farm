using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu (menuName = "Scriptable Objects/Crop Data", fileName = "New Crop Data")]
public class CropData : ScriptableObject
{

    public int timeToGrow = 10;
    public List<Sprite> sprites;
    public List<int> growthStageTime;
    
    [SerializeField] private CropDrops[] cropDrops;
    public CropDrops[] CropDrops => cropDrops;
    
}

[System.Serializable]
public class CropDrops
{
    [SerializeField] private Item item;
    [SerializeField] private int quantity;

    public Item Item => item;
    public int Quantity => quantity;

}
