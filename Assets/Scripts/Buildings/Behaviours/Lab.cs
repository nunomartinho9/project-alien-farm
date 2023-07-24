using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab : MonoBehaviour, IBuildingBehaviour
{
    [SerializeField] private FloatManagerSo earthLife;

    [SerializeField] private float maxValueUpgrade;
    // Update is called once per frame

    private void Start()
    {
        DoBehaviour();
    }
    public void DoBehaviour()
    {
        float oldMaxValue = earthLife.MaxValue;
        float newMaxValue = oldMaxValue + maxValueUpgrade;
        earthLife.MaxValue = newMaxValue;
        earthLife.IncreaseValue(newMaxValue-oldMaxValue);
        Debug.Log("Lab chamado");
    }
}