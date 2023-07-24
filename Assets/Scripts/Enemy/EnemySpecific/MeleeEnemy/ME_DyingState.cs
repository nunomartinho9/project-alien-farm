using UnityEngine;

public class ME_DyingState : DyingState
{
    private MeleeEnemy enemy;

    public ME_DyingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DyingState stateData, MeleeEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.seedManager.IncreaseSeedCount(enemy.seedDrop);
        Debug.Log("ALO1");
        enemy.enemyManager.IncreaseValue(1);
    }

    public override void Exit()
    {
        base.Exit();
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isDyingTimeOver)
        {
            stateMachine.currentState.Exit();
            enemy.Die();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}