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
    private void Start()
    {
        DoBehaviour();
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
    }
}
