using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Entity
{
    public RE_IdleState idleState { get; private set; }
    public RE_MovingState movingState { get; private set; }
    public RE_AttackingState attackingState { get; private set; }
    
    private Transform shootingPoint;

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MovingState movingStateData;
    [SerializeField] private D_AttackingState attackingStateData;
    [SerializeField] private GameObject projectile;
    

    public override void Start()
    {
        base.Start();

        movingState = new RE_MovingState(this, stateMachine, "moving", movingStateData, this);
        idleState = new RE_IdleState(this, stateMachine, "idle", idleStateData, this);
        attackingState = new RE_AttackingState(this, stateMachine, "attacking", attackingStateData, this);
        
        shootingPoint = alive.transform.Find("ShootingPoint").transform;
        
        stateMachine.Initialize(movingState);
    }

    public void Shoot()
    {
        Rigidbody rb = Instantiate(projectile, shootingPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        rb.AddForce(transform.up * 8f, ForceMode.Impulse);
    }
}
