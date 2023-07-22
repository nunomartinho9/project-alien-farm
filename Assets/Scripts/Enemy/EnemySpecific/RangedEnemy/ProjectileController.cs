using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float speed = 150f;
    [SerializeField] private float timeToDestroy = 3f;
    [SerializeField] private FloatManagerSo floatManager;
    
    private GameObject projBody;
    private float damage = 10f;

    private void Start()
    {
        projBody = transform.Find("projectileBody").gameObject;
    }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }
    
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            floatManager.DecreaseValue(damage);
            Destroy(gameObject);
        }
    }
}