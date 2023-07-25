using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Entity
{
    public RE_IdleState idleState { get; private set; }
    public RE_MovingState movingState { get; private set; }
    public RE_AttackingState attackingState { get; private set; }
    public RE_DyingState dyingState { get; private set; }

    [SerializeField] public Transform shootingPoint;
    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MovingState movingStateData;
    [SerializeField] private D_AttackingState attackingStateData;
    [SerializeField] private D_DyingState dyingStateData;
    [SerializeField] private GameObject projectile;
    
    [SerializeField] public float seedDrop;
    [SerializeField] public RewardsManagerSo seedManager;
    [SerializeField] public FloatManagerSo hpManager;
    [SerializeField] public FloatManagerSo enemyManager;
    public SoundEffectSo meAttackSOund;
    public SoundEffectSo reDeathSound;
    public override void Start()
    {
        base.Start();
        movingState = new RE_MovingState(this, stateMachine, "moving", movingStateData, this);
        idleState = new RE_IdleState(this, stateMachine, "idle", idleStateData, this);
        attackingState = new RE_AttackingState(this, stateMachine, "attacking", attackingStateData, this);
        dyingState = new RE_DyingState(this, stateMachine, "dying", dyingStateData, this);
        stateMachine.Initialize(movingState);
        
    }

    public void Shoot()
    {
        shootingPoint.LookAt(TargetPosition());
        Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
    }
}
