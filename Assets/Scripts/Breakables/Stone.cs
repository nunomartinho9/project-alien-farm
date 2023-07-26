using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Stone : MonoBehaviour, IBreakable
{
    [SerializeField] private BreakableData data;
    private InventoryManager inventoryManager;
    [SerializeField] private ResourcesContainer resourcesContainer;
    private int life;
    private SpriteRenderer spriteRenderer;
    private PersistentBreakables breakablesContainer;
    [SerializeField] private GameObject collectable;
    private GameObject collectableInfo;
    public BreakableData Data => data;

    #region sounds
    
    [SerializeField] private SoundEffectSo rockMineSound;
    [SerializeField] private SoundEffectSo rockBreakSound;
    
    
    #endregion
    
    private void Start()
    {
        life = Data.StartingLife;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Data.Sprite;

        inventoryManager = GameObject.FindWithTag("GameController").GetComponent<InventoryManager>();
        breakablesContainer = GameObject.Find("Breakables").GetComponent<PersistentBreakables>();
    }

    public void Damage()
    {
        Item selectedItem = inventoryManager.GetSelectedItem(false);
        if (selectedItem != Data.RequiredItem) return;
        life--;
        rockMineSound.Play();
        if (life <= 0)
        {
            Drop();
            breakablesContainer.RemoveBreakable(Vector3Int.FloorToInt(transform.position));
            rockBreakSound.Play();
            Destroy(gameObject);
        }
    }

    public void Drop()
    {
        resourcesContainer.AddRocks(data.QuantityToDrop);
        GameObject go = Instantiate(collectable);
        
        if (resourcesContainer.Rocks == resourcesContainer.MaxResources)
        {
            collectableInfo = go.transform.GetChild(0).gameObject;
            collectableInfo.GetComponent<TMP_Text>().text = "Resources Full.";
            collectableInfo.GetComponent<TMP_Text>().color = Color.red;
        }
        else
        {
            collectableInfo = go.transform.GetChild(0).gameObject;
            collectableInfo.GetComponent<TMP_Text>().text = "+ " + data.QuantityToDrop + " Stone";
            collectableInfo.GetComponent<TMP_Text>().color = new Color(0, 255, 0, 255);
        }
        
        
        
        Destroy(go, 2f);
    }


}
