using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "Scriptable Objects/BreakableData", fileName = "New BreakableData")]
public class BreakableData : ScriptableObject
{

    
    [SerializeField] private Sprite sprite;
    public Sprite Sprite => sprite;

    [SerializeField] private int startingLife;
    public int StartingLife => startingLife;
    
    [SerializeField] private Item requiredItem;
    public Item RequiredItem => requiredItem;

    [SerializeField] private int quantityToDrop;
    public int QuantityToDrop => quantityToDrop;
}

