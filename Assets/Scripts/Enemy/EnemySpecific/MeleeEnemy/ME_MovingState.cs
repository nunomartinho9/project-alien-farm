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
