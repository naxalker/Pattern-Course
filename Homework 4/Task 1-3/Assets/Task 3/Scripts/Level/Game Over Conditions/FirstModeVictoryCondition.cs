using System;
using System.Collections.Generic;

namespace sceneloader
{
    public class FirstModeVictoryCondition : IGameOverCondition
    {
        public event Action Won;
        public event Action Lost;

        private List<Ball> _balls;

        public void Initialize(List<Ball> spawnedBalls)
        {
            _balls = new List<Ball>(spawnedBalls);

            foreach (Ball ball in _balls)
            {
                ball.Popped += OnBallPopped;
            }
        }

        private void OnBallPopped(Ball ball)
        {
            _balls.Remove(ball);
            ball.Popped -= OnBallPopped;

            if (_balls.Count == 0)
                Won?.Invoke();
        }
    }
}