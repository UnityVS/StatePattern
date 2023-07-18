using UnityEngine;

namespace Assets.Scripts
{
    public class NPCWalkingState : StateSwitcherInfo, IState
    {
        public NPCWalkingState(StateSwitcherInfo stateSwitcherInfo) { _stateSwitcherInfo = stateSwitcherInfo; }
        protected float _timer = 0f;
        protected StateSwitcherInfo _stateSwitcherInfo;
        private bool _isStateBeforeNPCWorking;
        private float _walkingTime = 5;

        public virtual void Enter() { Debug.Log(ToString()); }

        public virtual void Exit() { }

        public virtual void Update()
        {
            _timer += Time.deltaTime;
            Debug.Log($"Я {_stateSwitcherInfo.GetNPC.name} иду еще {_walkingTime - _timer:F1}");
            if (_walkingTime <= _timer)
            {
                _timer = 0;
                if (_isStateBeforeNPCWorking)
                {
                    _isStateBeforeNPCWorking = false;
                    _stateSwitcherInfo.GetStateSwitcher.SwitchState<NPCIdlingState>();
                }
                else
                {
                    _isStateBeforeNPCWorking = true;
                    _stateSwitcherInfo.GetStateSwitcher.SwitchState<NPCWorkingState>();
                }
            }

        }
    }
}
