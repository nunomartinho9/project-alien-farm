using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private RecipeData recipe;
    [SerializeField] private ScriptableBool bridgeState;
    [SerializeField] private GameObject craftCanvas;
    [SerializeField] private GameObject builtBridgeGO;
    private bool isColliding;
    void Start()
    {
        gameObject.SetActive(bridgeState);
    }

    // Update is called once per frame
    void Update()
    {
        craftCanvas.SetActive(isColliding);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) isColliding = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) isColliding = false;
    }

    public void BuildBridge()
    {
        if (!recipe.CanCraft())
        {
            Debug.Log("CANT CRAFT BRIDGE");
            return;
        }

        recipe.Craft();
        bridgeState.isActive = false;
        builtBridgeGO.SetActive(true);
        gameObject.SetActive(bridgeState);
    }
}
