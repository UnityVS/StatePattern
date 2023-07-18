using System.Linq;

namespace Assets.Scripts
{
    public class StateSwitcherInfo
    {
        private NPC _npc;
        private IStateSwitcher _stateSwitcher;
        public void InitStateSwitcherInfo(IStateSwitcher stateSwitcher, NPC npc)
        {
            _stateSwitcher = stateSwitcher;
            _npc = npc;
        }

        public IStateSwitcher GetStateSwitcher => _stateSwitcher;
        public NPC GetNPC => _npc;
    }
}