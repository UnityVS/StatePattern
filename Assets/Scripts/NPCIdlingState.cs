﻿using UnityEngine;

namespace Assets.Scripts
{
    public class NPCIdlingState : NPCWalkingState
    {
        private float _timeToWalk = 3f;

        public NPCIdlingState(StateSwitcherInfo stateSwitcherInfo) : base(stateSwitcherInfo){}

        public override void Enter() => base.Enter();

        public override void Exit() => base.Exit();

        public override void Update()
        {
            _timer += Time.deltaTime;
            Debug.Log($"Я отдыхаю, пойду работать, через {_timeToWalk - _timer:F1} секунд");
            if (_timeToWalk <= _timer)
            {
                _timer = 0;
                _stateSwitcherInfo.GetStateSwitcher.SwitchState<NPCWalkingState>();
            }
        }
    }
}
