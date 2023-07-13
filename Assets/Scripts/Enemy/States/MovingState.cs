using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingState : State
{
    protected D_MovingState stateData;

    public MovingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MovingState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity.StartMoving(stateData.movementSpeed);
    }

    public override void Exit()
    {
        base.Exit();
        entity.StopMoving();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
