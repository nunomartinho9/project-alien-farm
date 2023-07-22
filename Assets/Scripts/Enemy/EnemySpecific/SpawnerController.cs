using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private int meleeCount;
    [SerializeField] private GameObject meleeEnemyPrefab;
    
    [SerializeField] private int rangedCount;
    [SerializeField] private GameObject rangedEnemyPrefab;

    private Transform spawnPoint;
    private int spawnedCounter;
    private float spawnCountdown;
    private float timeBetweenSpawns = 5f;
    
    void Start()
    {
        spawnPoint = gameObject.transform.Find("SpawnPoint");
        spawnedCounter = 0;
        spawnCountdown = timeBetweenSpawns;
        Instantiate(meleeEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void Update()
    {
        if (!AllSpawned())
        {
            if (spawnCountdown <= 0)
            {
                SpawnCooser();
            }
            else
            {
                spawnCountdown -= Time.deltaTime;
            }
        }   
    }

    private bool AllSpawned()
    {
        return Equals(spawnedCounter, rangedCount + meleeCount);
    }

    private void SpawnCooser()
    {
        var position = spawnPoint.position;
        var rotation = spawnPoint.rotation;
        if (spawnedCounter % 2 == 0)
        {
            SpawnMelee(position, rotation);
        }
        else
        {
            SpawnRanged(position, rotation);
        }
        spawnedCounter++;
        spawnCountdown = timeBetweenSpawns;
    }

    private void SpawnMelee(Vector3 position, Quaternion rotation)
    {
        Instantiate(meleeEnemyPrefab, position, rotation);
        Instantiate(meleeEnemyPrefab, position, rotation);
    }
    
    private void SpawnRanged(Vector3 position, Quaternion rotation)
    {
        Instantiate(rangedEnemyPrefab, position, rotation);
    }
}
