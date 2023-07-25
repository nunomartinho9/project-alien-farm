using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lab : MonoBehaviour, IBuildingBehaviour
{
    [SerializeField] private FloatManagerSo earthLife;

    [SerializeField] private float maxValueUpgrade;
    [SerializeField] private GameObject collectable;
    private GameObject collectableInfo;
    [SerializeField] private PlaceableObjectsContainer poContainer;
    private PlaceableObject po;
    // Update is called once per frame

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
        float oldMaxValue = earthLife.MaxValue;
        float newMaxValue = oldMaxValue + maxValueUpgrade;
        earthLife.MaxValue = newMaxValue;
        earthLife.IncreaseValue(newMaxValue-oldMaxValue);
        Debug.Log("Lab chamado");
        GameObject go = Instantiate(collectable);
        
        collectableInfo = go.transform.GetChild(0).gameObject;
        collectableInfo.GetComponent<TMP_Text>().text = "Humans can survive " + (newMaxValue-oldMaxValue) + "s longer!";
        collectableInfo.GetComponent<TMP_Text>().color = Color.green;
        Destroy(go, 1.1f);
        po.isBehaviourDone = true;
    }
}