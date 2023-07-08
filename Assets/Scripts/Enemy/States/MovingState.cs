using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : State
{
    protected D_MovingState stateData;
    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    
    public MovingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MovingState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(stateData.movementSpeed);
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
    }
}
