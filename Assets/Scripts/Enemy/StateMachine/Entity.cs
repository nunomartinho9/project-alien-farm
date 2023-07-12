using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;

    public D_Entity entityData;
    
    //public int facingDirection { get; private set; }
    public bool targetInAttackRange { get; private set; }
    public Rigidbody rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject alive { get; private set; }
    public NavMeshAgent agent { get; private set; }

    [SerializeField] private Transform target;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;

    private Vector2 velocityWorkspace;

    public virtual void Start()
    {
        //facingDirection = -1;
        
        alive = transform.Find("Alive").gameObject;
        rb = alive.GetComponent<Rigidbody>();
        anim = alive.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        
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

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, alive.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }

    public virtual Vector3 TargetPosition()
    {
        return target.position;
    }

    public virtual void TargetInAttackRange()
    {
        targetInAttackRange = Physics.CheckSphere(transform.position, entityData.attackRange, entityData.whatIsPlayer);
    }
}
