using System;

namespace RopeMaster.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public int Score;
        public PlayerProgress()
        {
            Score = 0;
        }
    }
}