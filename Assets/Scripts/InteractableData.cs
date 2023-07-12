using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Scriptable Objects/Interactable Data", fileName = "New Interactable Data")]
public class InteractableData : ScriptableObject
{

    //[SerializeField] private bool needsToCollide;

    // public bool NeedsToCollide => needsToCollide;

    [SerializeField] private Item requiredItem;
    
    public Item RequiredItem => requiredItem;
    
    [SerializeField] private bool needsItemToInteract;

    public bool NeedsItemToInteract => needsItemToInteract;
}
