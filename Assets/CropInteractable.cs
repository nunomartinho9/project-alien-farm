using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropInteractable : MonoBehaviour, IInteractable
{


    public InteractableData Data { get; }

    private GameManager gameManager;
    [SerializeField] private Player2DInfo playerInfo;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void Interact()
    {
        Debug.Log("crop interact");
       gameManager.CropManager.GetGrownCrop(playerInfo.position);
       
       
    }
}
