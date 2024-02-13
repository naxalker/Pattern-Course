using System;
using Zenject;

namespace sceneloader
{
    public class LevelUIMediator : IInitializable, IDisposable
    {
        private Level _level;
        private LevelUI _levelUI;

        public LevelUIMediator(Level level, LevelUI levelUI)
        {
            _level = level;
            _levelUI = levelUI;
        }

        public void Initialize()
        {
            _level.Won += OnWon;
            _level.Lost += OnLost;

            if (_level.VictoryCondition is SecondModeVictoryCondition)
                _levelUI.DisplayTargetColor(((SecondModeVictoryCondition)_level.VictoryCondition).TargetBallType);
        }

        public void Dispose()
        {
            _level.Won -= OnWon;
            _level.Lost -= OnLost;
        }

        private void OnWon() => _levelUI.ShowGameOverPanel(true);

        private void OnLost() => _levelUI.ShowGameOverPanel(false);
    }
}