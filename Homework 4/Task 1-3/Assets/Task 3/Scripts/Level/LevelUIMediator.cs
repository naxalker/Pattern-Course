using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

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

            _levelUI.ModeSelected += OnModeSelected;
            _levelUI.FirstModeSelected += OnFirstModeSelected;
            _levelUI.SecondModeSelected += OnSecondModeSelected;
        }

        public void Dispose()
        {
            _level.Won -= OnWon;
            _level.Lost -= OnLost;

            _levelUI.ModeSelected -= OnModeSelected;
            _levelUI.FirstModeSelected -= OnFirstModeSelected;
            _levelUI.SecondModeSelected -= OnSecondModeSelected;
        }

        private void OnLost() => _levelUI.ShowEndPanel(false);

        private void OnWon() => _levelUI.ShowEndPanel(true);

        private void OnModeSelected()
            => _level.StartLevel();

        private void OnFirstModeSelected()
            => _level.SetVictoryCondition(new FirstModeVictoryCondition(_level.Spawner.SpawnedBalls));

        private void OnSecondModeSelected()
        {
            List<Ball> balls = _level.Spawner.SpawnedBalls;
            BallType ballType = balls[Random.Range(0, balls.Count)].Type;

            _level.SetVictoryCondition(new SecondModeVictoryCondition(balls, ballType));

            switch (ballType)
            {
                case BallType.Red:
                    _levelUI.SetTargetColor(Color.red);
                    break;

                case BallType.Green:
                    _levelUI.SetTargetColor(Color.green);
                    break;

                case BallType.Yellow:
                    _levelUI.SetTargetColor(Color.yellow);
                    break;
            }
            
        }
    }
}