﻿    public class RE_DyingState : DyingState
    {
        private RangedEnemy enemy;

        public RE_DyingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DyingState stateData, RangedEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
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
            if (isDyingTimeOver)
            {
                enemy.Die();
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }