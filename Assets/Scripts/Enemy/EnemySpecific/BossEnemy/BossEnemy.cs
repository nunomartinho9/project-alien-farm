using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Entity
{
    public BE_IdleState idleState { get; private set; }
    public BE_MovingState movingState { get; private set; }
    public BE_AttackingState attackingState { get; private set; }
    public BE_DyingState dyingState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MovingState movingStateData;
    [SerializeField] private D_AttackingState attackingStateData;
    [SerializeField] private D_DyingState dyingStateData;

    public override void Start()
    {
        base.Start();

        movingState = new BE_MovingState(this, stateMachine, "moving", movingStateData, this);
        idleState = new BE_IdleState(this, stateMachine, "idle", idleStateData, this);
        attackingState = new BE_AttackingState(this, stateMachine, "attacking", attackingStateData, this);
        dyingState = new BE_DyingState(this, stateMachine, "dying", dyingStateData, this);
        
        stateMachine.Initialize(movingState);
    }
}
