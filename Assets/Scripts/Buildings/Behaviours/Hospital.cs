using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hospital : MonoBehaviour, IBuildingBehaviour
{
    [SerializeField] private FloatManagerSo earthLife;
    [SerializeField] private int valueToHeal;

    [SerializeField] private float coolDownToHeal;
    [SerializeField] private float cooldownGetFuel;
    [SerializeField] private ResourcesContainer resources;
    [SerializeField] private int fuelNeeded;
    [SerializeField] private GameObject collectable;
    private GameObject collectableInfo;
    private bool hasFuel;
    private float timestamp, timestamp2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        hasFuel = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (hasFuel)
        {
            DoBehaviour();
        }
        
        if (timestamp2 <= Time.time)
        {
            if (resources.StarCrops >= fuelNeeded)
            {
                hasFuel = true;
                resources.UseStarCrop(fuelNeeded);
                GameObject go = Instantiate(collectable);
        
                collectableInfo = go.transform.GetChild(0).gameObject;
                collectableInfo.GetComponent<TMP_Text>().text = "Used " + fuelNeeded + "  stars to fuel the hospital";
                Debug.Log(fuelNeeded);
                collectableInfo.GetComponent<TMP_Text>().color = Color.green;
                Destroy(go, 1.1f);
            }
            else
            {
                Debug.Log("n tem fuel");
                GameObject go = Instantiate(collectable);
        
                collectableInfo = go.transform.GetChild(0).gameObject;
                collectableInfo.GetComponent<TMP_Text>().text = "Not enough fuel to help humans";
                collectableInfo.GetComponent<TMP_Text>().color = Color.red;
                Destroy(go, 1.1f);
                hasFuel = false;
            }
            timestamp2 = Time.time + cooldownGetFuel;
        }

    }

    public void DoBehaviour()
    {
        if (timestamp <= Time.time)
        {
            earthLife.IncreaseValue(valueToHeal);
            timestamp = Time.time + coolDownToHeal;
            Debug.Log("HELEAD");
            GameObject go = Instantiate(collectable);
        
            collectableInfo = go.transform.GetChild(0).gameObject;
            collectableInfo.GetComponent<TMP_Text>().text = "Healed " + valueToHeal + " humans!";
            collectableInfo.GetComponent<TMP_Text>().color = Color.green;
            Destroy(go, 1.1f);
        }
    }
}
