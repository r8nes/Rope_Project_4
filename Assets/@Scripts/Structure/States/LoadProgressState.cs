namespace RopeMaster.State
{
    public class LoadProgressState : IState
    {
        private const string START_SCENE = "Main";
        private readonly GameStateMachine _gameStateMachine;

        public LoadProgressState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter() => _gameStateMachine.Enter<LoadLevelState, string>(START_SCENE);

        public void Exit() { }
    }
}   