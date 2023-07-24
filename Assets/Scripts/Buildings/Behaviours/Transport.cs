using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour, IBuildingBehaviour
{
    [SerializeField] private RewardsManagerSo actionGameInfo;

    private void Start()
    {
        DoBehaviour();
    }

    public void DoBehaviour()
    {
        Debug.Log("fui chamado transport");
        actionGameInfo.UpgradePopulationGain();
    }
}
