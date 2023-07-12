using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "Scriptable Objects/BreakableData", fileName = "New BreakableData")]
public class BreakableData : ScriptableObject
{

    [SerializeField] private Sprite sprite;
    [SerializeField] private Item requiredItem;
    [SerializeField] private int startingLife;
    [SerializeField] private DropList[] dropLists;

    public Sprite Sprite => sprite;

    public int StartingLife => startingLife;

    public Item RequiredItem => requiredItem;

    public DropList[] DropLists => dropLists;
}

[System.Serializable]
public class DropList
{
    [SerializeField] private Item item;
    [SerializeField] private int quantity;

    public Item Item => item;
    public int Quantity => quantity;

}
