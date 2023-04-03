using RopeMaster.State;
using UnityEngine;

namespace RopeMaster.System
{
    public class Bootstrap : MonoBehaviour, ICoroutineRunner
    {
        
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
