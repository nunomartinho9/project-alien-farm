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
        //TODO SAIR DO IDLE QUANDO O COLDOWN DE ATAQUE ACABAR
        //TODO OU QUANDO O PLAYER SAIR DA ZONA DE ATAQUE
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
