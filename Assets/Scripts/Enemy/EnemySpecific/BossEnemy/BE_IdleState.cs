using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE_IdleState : IdleState
{
    private BossEnemy enemy;
    
    public BE_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, BossEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        if(enemy.TargetInAttackRange() && Time.time >= startTime + stateData.idleTime)
        {
            stateMachine.ChangeState(enemy.attackingState);
        }else if (!enemy.TargetInAttackRange() && Time.time >= startTime + stateData.idleTime)
        {
            stateMachine.ChangeState(enemy.movingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
