using UnityEngine;

public class DyingState : State
{
    protected D_DyingState stateData;
    protected bool isDyingTimeOver;


    public DyingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DyingState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered DyingState");
        entity.StopMoving();
        isDyingTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Left DyingState");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + stateData.isDyingTimeOver)
        {
            isDyingTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}