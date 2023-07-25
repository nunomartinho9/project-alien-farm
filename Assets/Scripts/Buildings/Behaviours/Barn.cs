using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barn : MonoBehaviour, IBuildingBehaviour
{
    [SerializeField] private ResourcesContainer container;
    [SerializeField] private PlaceableObjectsContainer poContainer;
    [SerializeField] private GameObject collectable;
    private GameObject collectableInfo;
    private PlaceableObject po;
    private void Start()
    {
        Vector3Int position = Vector3Int.FloorToInt(transform.position);
        po = poContainer.Get(position);
        if (po == null) return;
        if (!po.isBehaviourDone)
        {
            DoBehaviour();
        }

    }

    public void DoBehaviour()
    {
        container.UpgradeMaxStacks();
        GameObject go = Instantiate(collectable);
        
        collectableInfo = go.transform.GetChild(0).gameObject;
        collectableInfo.GetComponent<TMP_Text>().text = "Max resources upgraded!";
        collectableInfo.GetComponent<TMP_Text>().color = Color.green;
        Destroy(go, 1.1f);

        po.isBehaviourDone = true;
    }
}
