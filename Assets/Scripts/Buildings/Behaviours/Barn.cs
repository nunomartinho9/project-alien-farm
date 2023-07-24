using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barn : MonoBehaviour, IBuildingBehaviour
{
    [SerializeField] private ResourcesContainer container;
    [SerializeField] private GameObject collectable;
    private GameObject collectableInfo;
    private void Start()
    {
        DoBehaviour();
    }

    public void DoBehaviour()
    {
        container.UpgradeMaxStacks();
        GameObject go = Instantiate(collectable);
        
        collectableInfo = go.transform.GetChild(0).gameObject;
        collectableInfo.GetComponent<TMP_Text>().text = "Max resources upgraded!";
        collectableInfo.GetComponent<TMP_Text>().color = Color.green;
        Destroy(go, 1.1f);
    }
}
