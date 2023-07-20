using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropInteractable : MonoBehaviour, IInteractable
{


    public InteractableData Data { get; }

    private CropManager cropManager;
    [SerializeField] private Player2DInfo playerInfo;

    private void Start()
    {
        cropManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<CropManager>();
    }

    public void Interact()
    {
        Debug.Log("crop interact");
        cropManager.GetGrownCrop(playerInfo.Position);
       
       
    }
}
