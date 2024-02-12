using System.Collections.Generic;

namespace sceneloader
{
    public class FirstModeVictoryCondition : IVictoryCondition
    {
        private List<Ball> _balls;

        public FirstModeVictoryCondition(List<Ball> spawnedBalls)
        {
            _balls = spawnedBalls;
        }

        public bool HasLost() => false;

        public bool HasWon() => _balls.Count == 0;
    }
}