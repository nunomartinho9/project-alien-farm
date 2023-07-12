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

    
    [SerializeField] private DropList[] dropLists;
    public DropList[] DropLists => dropLists;
    
    [SerializeField] private bool needsTool;
    public bool NeedsTool => needsTool;
}

[System.Serializable]
public class DropList
{
    [SerializeField] private Item item;
    [SerializeField] private int quantity;

    public Item Item => item;
    public int Quantity => quantity;

}
