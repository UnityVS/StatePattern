using UnityEngine;

namespace Assets.Scripts
{
    public class NPCWalkingState : IState
    {
        public NPCWalkingState(NPCStateMachine npcStateMachine) => _stateMachine = npcStateMachine;
        protected float _timer = 0f;
        protected NPCStateMachine _stateMachine;
        private bool _isStateBeforeNPCWorking;
        private float _walkingTime = 5;

        public virtual void Enter() { Debug.Log(ToString()); }

        public virtual void Exit() { }

        public virtual void Update()
        {
            _timer += Time.deltaTime;
            Debug.Log($"Я иду еще {_walkingTime - _timer:F1}");
            if (_walkingTime <= _timer)
            {
                _timer = 0;
                if (_isStateBeforeNPCWorking)
                {
                    _isStateBeforeNPCWorking = false;
                    _stateMachine.SwitchState<NPCIdlingState>();
                }
                else
                {
                    _isStateBeforeNPCWorking = true;
                    _stateMachine.SwitchState<NPCWorkingState>();
                }
            }

        }
    }
}
