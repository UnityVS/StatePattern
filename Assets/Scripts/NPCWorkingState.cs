using UnityEngine;

namespace Assets.Scripts
{
    public class NPCWorkingState : NPCWalkingState
    {
        public NPCWorkingState(StateSwitcherInfo stateSwitcherInfo) : base(stateSwitcherInfo){}
        private float _workingTime = 4f;

        public override void Enter() => base.Enter();

        public override void Exit() => base.Exit();

        public override void Update()
        {
            Timer += Time.deltaTime;
            Debug.Log($"Я работаю еще {_workingTime - Timer:F1}");
            if (_workingTime <= Timer)
            {
                Timer = 0;
                StateSwitcher.GetStateSwitcher.SwitchState<NPCWalkingState>();
            }
        }
    }
}
