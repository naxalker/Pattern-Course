using System.Collections.Generic;
using System.Linq;

namespace sceneloader
{
    public class SecondModeVictoryCondition : IVictoryCondition
    {
        private int _originNonTargetedBallsCount;
        private List<Ball> _balls;
        private BallType _targetBallType;

        public SecondModeVictoryCondition(List<Ball> spawnedBalls, BallType targetType)
        {
            _balls = spawnedBalls;
            _targetBallType = targetType;

            _originNonTargetedBallsCount = _balls
                .Where(ball => ball.Type != _targetBallType)
                .Count();
        }

        public bool HasLost()
        {
            List<Ball> nonTargetedBalls = new List<Ball>(_balls
                .Where(ball => ball.Type != _targetBallType));

            return nonTargetedBalls.Count != _originNonTargetedBallsCount;
        }

        public bool HasWon()
        {
            List<Ball> targetedBalls = new List<Ball>(_balls
                .Where(ball => ball.Type == _targetBallType));

            return targetedBalls.Count == 0;
        }
    }
}