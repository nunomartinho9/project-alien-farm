using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Entity
{
    public ME_IdleState idleState { get; private set; }
    public ME_MovingState movingState { get; private set; }
    public ME_AttackingState attackingState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MovingState movingStateData;
    [SerializeField] private D_AttackingState attackingStateData;

    public override void Start()
    {
        base.Start();

        movingState = new ME_MovingState(this, stateMachine, "moving", movingStateData, this);
        idleState = new ME_IdleState(this, stateMachine, "idle", idleStateData, this);
        attackingState = new ME_AttackingState(this, stateMachine, "attacking", attackingStateData, this);
        
        stateMachine.Initialize(movingState);
    }
}
