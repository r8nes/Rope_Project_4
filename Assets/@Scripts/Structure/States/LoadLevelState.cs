using RopeMaster.Factory;
using UnityEngine;

namespace RopeMaster.State
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private readonly IGameFactory _gameFactory;
        private readonly GameStateMachine _gameStateMachine;

        public LoadLevelState(GameStateMachine gameStateMachine, IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(string sceneName)
        {
            OnLoaded();
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            InitGameWrold();
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitGameWrold()
        {
            var player = InitPlayer();
            var circle = InitSpawnCircle();

            circle.transform.parent = player.transform;
        }

        private GameObject InitPlayer() => _gameFactory.CreatePlayer(Vector2.zero);

        private GameObject InitSpawnCircle() => _gameFactory.CreateSpawnerDistributor();
    }
}