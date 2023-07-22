using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float speed = 150f;
    [SerializeField] private float timeToDestroy = 3f;
    
    private GameObject projBody;
    //private float damage = 10f;

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

    private void OnCollisionEnter(Collision other)
    {
        //if (other.gameObject.CompareTag("Player") )
        //{
          //  Damage();
        //}
        //Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("triggered");
            Destroy(gameObject);
        }
    }

    public void Damage()
    {
        //ToDo
    }
}