using UnityEngine;

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
            Timer += Time.deltaTime;
            Debug.Log($"Я отдыхаю, пойду работать, через {_timeToWalk - Timer:F1} секунд");
            if (_timeToWalk <= Timer)
            {
                Timer = 0;
                StateSwitcher.GetStateSwitcher.SwitchState<NPCWalkingState>();
            }
        }
    }
}
