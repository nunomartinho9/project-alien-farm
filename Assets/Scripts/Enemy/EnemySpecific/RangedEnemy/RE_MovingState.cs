using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RE_MovingState : MovingState
{
    private RangedEnemy enemy;
    
    public RE_MovingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MovingState stateData, RangedEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }


    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!enemy.IsAlive()) stateMachine.ChangeState(enemy.dyingState);
        if (enemy.TargetInAttackRange())
        {
            stateMachine.ChangeState(enemy.attackingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
