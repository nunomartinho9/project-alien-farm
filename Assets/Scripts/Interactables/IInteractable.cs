using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    InteractableData Data { get;  }
    
    void Interact();
}
