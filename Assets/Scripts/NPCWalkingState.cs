using UnityEngine;

namespace Assets.Scripts
{
    public class NPCWalkingState : StateSwitcherInfo, IState
    {
        public NPCWalkingState(StateSwitcherInfo stateSwitcherInfo) { StateSwitcher = stateSwitcherInfo; }
        protected float Timer = 0f;
        protected StateSwitcherInfo StateSwitcher;
        private bool _isStateBeforeNPCWorking;
        private float _walkingTime = 5;

        public virtual void Enter() { Debug.Log(ToString()); }

        public virtual void Exit() { }

        public virtual void Update()
        {
            Timer += Time.deltaTime;
            Debug.Log($"Я {StateSwitcher.GetNPC.name} иду еще {_walkingTime - Timer:F1}");
            if (_walkingTime <= Timer)
            {
                Timer = 0;
                if (_isStateBeforeNPCWorking)
                {
                    _isStateBeforeNPCWorking = false;
                    StateSwitcher.GetStateSwitcher.SwitchState<NPCIdlingState>();
                }
                else
                {
                    _isStateBeforeNPCWorking = true;
                    StateSwitcher.GetStateSwitcher.SwitchState<NPCWorkingState>();
                }
            }

        }
    }
}
