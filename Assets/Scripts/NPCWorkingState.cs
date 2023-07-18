﻿using UnityEngine;

namespace Assets.Scripts
{
    public class NPCWorkingState : NPCWalkingState
    {
        public NPCWorkingState(NPCStateMachine npcStateMachine) : base(npcStateMachine){}
        private float _workingTime = 4f;

        public override void Enter() => base.Enter();

        public override void Exit() => base.Exit();

        public override void Update()
        {
            _timer += Time.deltaTime;
            Debug.Log($"Я работаю еще {_workingTime - _timer:F1}");
            if (_workingTime <= _timer)
            {
                _timer = 0;
                _stateMachine.SwitchState<NPCWalkingState>();
            }
        }
    }
}