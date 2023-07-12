using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ME_IdleState : IdleState
{
    private MeleeEnemy enemy;
    
    public ME_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, MeleeEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        if(entity.TargetInAttackRange() && Time.time >= startTime + stateData.idleTime)
        {
            stateMachine.ChangeState(enemy.attackingState);
        }else if (!entity.TargetInAttackRange() && Time.time >= startTime + stateData.idleTime)
        {
            stateMachine.ChangeState(enemy.movingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
