using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;

    public D_Entity entityData;
    
    //public int facingDirection { get; private set; }
    public Rigidbody rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject alive { get; private set; }
    public NavMeshAgent agent { get; private set; }

    [SerializeField] private Transform target;
    

    private Vector2 velocityWorkspace;

    public virtual void Start()
    {
        alive = transform.Find("Alive").gameObject;
        rb = alive.GetComponent<Rigidbody>();
        anim = alive.GetComponent<Animator>();
        agent = alive.GetComponent<NavMeshAgent>();
        
        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual Vector3 TargetPosition()
    {
        return target.position;
    }

    public virtual bool TargetInAttackRange()
    {
        if (Vector3.Distance( alive.transform.position, TargetPosition()) < entityData.attackRange)
        {
            Debug.Log("inRange");
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
}
