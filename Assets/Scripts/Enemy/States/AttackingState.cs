using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : State
{
    protected D_AttackingState stateData;
    protected bool isAttackingTimeOver;


    public AttackingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_AttackingState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        isAttackingTimeOver = false;
        entity.StopMoving();
        entity.alive.transform.LookAt(entity.TargetPosition());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + stateData.isAttackingTimeOver)
        {
            isAttackingTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}