using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Entity
{
    public ME_IdleState idleState { get; private set; }
    public ME_MovingState movingState { get; private set; }
    public float damage = 5f;

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MovingState movingStateData;

    public override void Start()
    {
        base.Start();

        movingState = new ME_MovingState(this, stateMachine, "moving", movingStateData, this);
        idleState = new ME_IdleState(this, stateMachine, "idle", idleStateData, this);
        
        stateMachine.Initialize(movingState);
    }
}
