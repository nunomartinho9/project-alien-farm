using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float timeToDestroy = 3f;
    //private float damage = 10f;


    private void OnEnable()
    {
        gameObject.GetComponent<Rigidbody>().transform.eulerAngles = new Vector3(90, gameObject.GetComponent<Rigidbody>().transform.eulerAngles.y, gameObject.GetComponent<Rigidbody>().transform.eulerAngles.z);
        gameObject.GetComponent<Rigidbody>().AddForce(transform.up * speed, ForceMode.VelocityChange);
        Destroy(gameObject, timeToDestroy);
    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.GetContact(0);
        //if (other.gameObject.CompareTag("Enemy") )
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