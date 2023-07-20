using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;

    public D_Entity entityData;
    

    private float health;
    
    public Rigidbody rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject alive { get; private set; }
    public NavMeshAgent agent { get; private set; }

    [SerializeField] private Transform target;

    public virtual void Start()
    {
        health = entityData.startingHp;
        alive = transform.Find("Alive").gameObject;
        rb = alive.GetComponent<Rigidbody>();
        anim = alive.GetComponent<Animator>();
        agent = alive.GetComponent<NavMeshAgent>();
        
        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
        if (!IsAlive())
        {
            Die();
        }
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    //ToDo colisao com uma bala
    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            TakeDamage(damage);
        }
    }*/

    public virtual Vector3 TargetPosition()
    {
        return target.position;
    }

    public virtual bool TargetInAttackRange()
    {
        if (Vector3.Distance( alive.transform.position, TargetPosition()) < entityData.attackRange)
        {
            return true;
        }
        return false;
    }

    public virtual void StartMoving(float mSpeed)
    {
        agent.enabled = true;
        agent.speed = mSpeed;
        agent.acceleration = mSpeed;
        agent.SetDestination(TargetPosition());
        
    }
    
    public virtual void StopMoving()
    {
        agent.enabled = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public bool IsAlive()
    {
        return !(health <= 0);
    }
    
    public void Die()
    {
        Destroy(gameObject);
    }
}
