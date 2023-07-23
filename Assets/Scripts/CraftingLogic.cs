using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CraftingLogic : MonoBehaviour
{

    [SerializeField] private List<GameObject> blueprints;
    [SerializeField] private GameObject craftGO;

    public void SpawnBlueprint(int index)
    {
        Debug.Log(index);
        craftGO.SetActive(false);
        Instantiate(blueprints[index], transform.position, transform.rotation);
    }


}
