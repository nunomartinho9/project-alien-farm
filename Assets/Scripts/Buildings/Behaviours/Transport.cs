using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Transport : MonoBehaviour, IBuildingBehaviour
{
    [SerializeField] private RewardsManagerSo actionGameInfo;
    [SerializeField] private GameObject collectable;
    private GameObject collectableInfo;
    [SerializeField] private PlaceableObjectsContainer poContainer;
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
        Debug.Log("fui chamado transport");
        actionGameInfo.UpgradePopulationGain();
        GameObject go = Instantiate(collectable);
        
        collectableInfo = go.transform.GetChild(0).gameObject;
        collectableInfo.GetComponent<TMP_Text>().text = "More transports, More resources brought from combat!";
        collectableInfo.GetComponent<TMP_Text>().color = Color.green;
        Destroy(go, 1.1f);
        po.isBehaviourDone = true;
    }
}
