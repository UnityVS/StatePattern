using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts
{
    public class NPCStateMachine : IStateSwitcher
    {
        private List<IState> _states;
        private IState _currentState;
        private StateSwitcherInfo _switcherInfo = new();

        public NPCStateMachine(NPC npc)
        {
            _switcherInfo.InitStateSwitcherInfo(this, npc);
            _states = new List<IState>()
            {
                new NPCWalkingState(this),
                new NPCIdlingState(this),
                new NPCWorkingState(this)
            };
            _currentState = _states[1];
            _currentState.Enter();
        }

        public void UpdateFromStateMachine() => _currentState.Update();

        public void SwitchState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(state => state is T);

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}
