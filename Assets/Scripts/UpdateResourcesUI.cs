using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateResourcesUI : MonoBehaviour
{

    [SerializeField] private GameObject wood;
    [SerializeField] private GameObject rocks;
    [SerializeField] private GameObject stars;
    [SerializeField] private GameObject seeds;
    [SerializeField] private TMP_Text maxText;
    [SerializeField] private ResourcesContainer resourcesContainer;

    private void OnEnable()
    {
        resourcesContainer.updateResourcesEvent.AddListener(UpdateUI); 
    }

    private void OnDisable()
    {
        resourcesContainer.updateResourcesEvent.RemoveListener(UpdateUI); 
    }

    void UpdateUI()
    {
        wood.transform.GetChild(1).GetComponent<TMP_Text>().text = resourcesContainer.Wood.ToString();
        rocks.transform.GetChild(1).GetComponent<TMP_Text>().text = resourcesContainer.Rocks.ToString();
        stars.transform.GetChild(1).GetComponent<TMP_Text>().text = resourcesContainer.StarCrops.ToString();
        seeds.transform.GetChild(1).GetComponent<TMP_Text>().text = resourcesContainer.Seeds.ToString();
        maxText.text = resourcesContainer.MaxResources.ToString();
    }
}
