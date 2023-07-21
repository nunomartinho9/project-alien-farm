using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float speed = 60f;
    [SerializeField] private float timeToDestroy = 3f;
    
    private GameObject projBody;
    //private float damage = 10f;

    private void Start()
    {
        projBody = transform.Find("projectileBody").gameObject;
    }

    private void OnEnable()
    {
        //gameObject.GetComponent<Rigidbody>().transform.eulerAngles = new Vector3(90, gameObject.GetComponent<Rigidbody>().transform.eulerAngles.y, gameObject.GetComponent<Rigidbody>().transform.eulerAngles.z);
        //gameObject.GetComponent<Rigidbody>().AddForce(transform.up * speed, ForceMode.Impulse);
        //gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * -10f, ForceMode.Impulse);
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
        Destroy(gameObject);
    }

    public void Damage()
    {
        //ToDo
    }
}