using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CraftingLogic : MonoBehaviour
{

    [SerializeField] private List<GameObject> blueprints;
    [SerializeField] private GameObject craftGO;
    private GameObject instatietedBlueprint;
    private void Update()
    {
        DespawnBlueprint();
    }

    public void SpawnBlueprint(int index)
    {
        Blueprint b = blueprints[index].gameObject.GetComponent<Blueprint>();
        Debug.Log(index);

        if (b.GetRecipe.CanCraft())
        {
            craftGO.SetActive(false);
            instatietedBlueprint = Instantiate(blueprints[index], transform.position, transform.rotation);
            
        }
        else
        {
            Debug.Log("CANT CRAFT, DONT HAVE NECESSARY RESOURCES");
        }
        
    }

    private void DespawnBlueprint()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (instatietedBlueprint == null) return;
            Debug.Log("cancel build");
            Destroy(instatietedBlueprint.gameObject);
            instatietedBlueprint = null;
        }
    }


}
