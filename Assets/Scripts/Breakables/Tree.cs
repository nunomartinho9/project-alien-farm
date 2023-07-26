using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tree : MonoBehaviour, IBreakable
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

    [SerializeField] private SoundEffectSo treeBreakSound;
    [SerializeField] private SoundEffectSo treeChopSound;

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
        treeChopSound.Play();
        if (life <= 0)
        {
            Drop();
            breakablesContainer.RemoveBreakable(Vector3Int.FloorToInt(transform.position));
            treeBreakSound.Play();
            Destroy(gameObject);
        }
    }

    public void Drop()
    {
        resourcesContainer.AddWood(data.QuantityToDrop);
        GameObject go = Instantiate(collectable);
        
        collectableInfo = go.transform.GetChild(0).gameObject;
        collectableInfo.GetComponent<TMP_Text>().text = "+ " + data.QuantityToDrop + " Wood";
        collectableInfo.GetComponent<TMP_Text>().color = new Color(0, 255, 0, 255);
        Destroy(go, 2f);
    }
}
