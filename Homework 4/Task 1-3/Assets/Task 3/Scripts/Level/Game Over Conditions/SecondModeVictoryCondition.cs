using System;
using System.Collections.Generic;

namespace sceneloader
{
    public class SecondModeVictoryCondition : IGameOverCondition
    {
        public event Action Won;
        public event Action Lost;

        private List<Ball> _balls;
        private BallType _targetBallType;

        private int _originTargetedBallsCount;

        public SecondModeVictoryCondition(BallType targetBallType)
        {
            _targetBallType = targetBallType;
        }

        public BallType TargetBallType => _targetBallType;

        public void Initialize(List<Ball> spawnedBalls)
        {
            _originTargetedBallsCount = 0;

            _balls = new List<Ball>(spawnedBalls);

            foreach (Ball ball in _balls)
            {
                ball.Popped += OnBallPopped;
                if (ball.Type == _targetBallType)
                    _originTargetedBallsCount++;
            }
        }

        private void OnBallPopped(Ball ball)
        {
            _balls.Remove(ball);
            ball.Popped -= OnBallPopped;

            if (ball.Type != _targetBallType)
            {
                Lost?.Invoke();
            }
            else
            {
                _originTargetedBallsCount--;

                if (_originTargetedBallsCount == 0)
                    Won?.Invoke();
            }
        }
    }
}