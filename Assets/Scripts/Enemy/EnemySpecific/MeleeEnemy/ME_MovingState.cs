using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ME_MovingState : MovingState
{
    private MeleeEnemy enemy;
    
    public ME_MovingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MovingState stateData, MeleeEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }


    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered MovingState");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Left MovingState");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        entity.transform.LookAt(entity.TargetPosition());
        if (entity.TargetInAttackRange())
        {
            stateMachine.ChangeState(enemy.attackingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
