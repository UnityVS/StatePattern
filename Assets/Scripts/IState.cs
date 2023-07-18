namespace Assets.Scripts
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update();
    }
}
