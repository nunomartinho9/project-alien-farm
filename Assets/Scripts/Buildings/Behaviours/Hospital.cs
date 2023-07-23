using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : MonoBehaviour, IBuildingBehaviour
{
    [SerializeField] private FloatManagerSo earthLife;
    [SerializeField] private int valueToHeal;

    [SerializeField] private float coolDownToHeal;
    [SerializeField] private float cooldownGetFuel;
    [SerializeField] private ResourcesContainer resources;
    [SerializeField] private int fuelNeeded;
    private bool hasFuel;
    private float timestamp, timestamp2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        timestamp = Time.time + coolDownToHeal;
        timestamp2 = Time.time + cooldownGetFuel;
        hasFuel = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timestamp2 <= Time.time)
        {
            if (resources.StarCrops >= fuelNeeded)
            {
                resources.UseStarCrop(fuelNeeded);
                hasFuel = true;
            }
            else
            {
                Debug.Log("n tem fuel");
                hasFuel = false;
            }
            timestamp2 = Time.time + cooldownGetFuel;
        }


        if (hasFuel)
        {
            DoBehaviour();
        }
        
    }

    public void DoBehaviour()
    {
        if (timestamp <= Time.time)
        {
            earthLife.IncreaseValue(valueToHeal);
            timestamp = Time.time + coolDownToHeal;
            Debug.Log("HELEAD");
        }
    }
}
