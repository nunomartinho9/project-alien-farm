using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private float speed = 30f;
    //private float damage = 10f;
    private float timeToDestroy = 3f;
    private Rigidbody rb;
    
    

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.GetContact(0);
        if (other.gameObject.CompareTag("Enemy") )
        {
            //TODO DAR O DANO
        }
        Destroy(gameObject);
    }
}
