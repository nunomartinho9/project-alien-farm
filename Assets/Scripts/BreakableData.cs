using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "Scriptable Objects/BreakableData", fileName = "New BreakableData")]
public class BreakableData : ScriptableObject
{

    [SerializeField] private Sprite sprite;
    [SerializeField] private Item requiredItem;

    public Sprite Sprite
    {
        get => sprite;
    }

    public Item RequiredItem
    {
        get => requiredItem;
    }

}
