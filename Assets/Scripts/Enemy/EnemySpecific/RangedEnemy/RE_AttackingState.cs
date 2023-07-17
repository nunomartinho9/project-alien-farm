using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RE_AttackingState : AttackingState
{
    private RangedEnemy enemy;
    private ProjectileController pController;

    public RE_AttackingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_AttackingState stateData, RangedEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.Shoot();
    }

    public override void Exit()
    {
        base.Exit();
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!enemy.IsAlive()) stateMachine.ChangeState(enemy.dyingState);
        if (isAttackingTimeOver)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
