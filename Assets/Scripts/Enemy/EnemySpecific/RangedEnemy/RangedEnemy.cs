using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Entity
{
    public RE_IdleState idleState { get; private set; }
    public RE_MovingState movingState { get; private set; }
    public RE_AttackingState attackingState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MovingState movingStateData;
    [SerializeField] private D_AttackingState attackingStateData;

    public override void Start()
    {
        base.Start();

        movingState = new RE_MovingState(this, stateMachine, "moving", movingStateData, this);
        idleState = new RE_IdleState(this, stateMachine, "idle", idleStateData, this);
        attackingState = new RE_AttackingState(this, stateMachine, "attacking", attackingStateData, this);
        
        stateMachine.Initialize(movingState);
    }
}
