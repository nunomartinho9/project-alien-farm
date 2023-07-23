using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : MonoBehaviour, IBuildingBehaviour
{
    [SerializeField] private ResourcesContainer container;

    private void Start()
    {
        DoBehaviour();
    }

    public void DoBehaviour()
    {
        container.UpgradeMaxStacks();
    }
}
