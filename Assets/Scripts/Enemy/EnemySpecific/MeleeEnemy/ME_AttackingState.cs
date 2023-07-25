using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ME_AttackingState : AttackingState
{
    private MeleeEnemy enemy;
    
    public ME_AttackingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_AttackingState stateData, MeleeEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.hpManager.DecreaseValue(enemy.entityData.attackDamage);
        enemy.meAttackSOund.Play();
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
