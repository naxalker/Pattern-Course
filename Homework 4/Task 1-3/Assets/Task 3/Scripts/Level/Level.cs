using System;
using UnityEngine;
using Zenject;

namespace sceneloader
{
    public class Level : IInitializable, IDisposable
    {
        public event Action Won;
        public event Action Lost;

        private IGameOverCondition _victoryCondition;
        private BallsSpawner _spawner;

        public Level(IGameOverCondition victoryCondition, BallsSpawner spawner)
        {
            _victoryCondition = victoryCondition;
            _spawner = spawner;
        }

        public IGameOverCondition VictoryCondition => _victoryCondition;

        public void Initialize()
        {
            Debug.Log(_victoryCondition.GetType());

            _spawner.SpawnBalls();
            _victoryCondition.Initialize(_spawner.SpawnedBalls);

            _victoryCondition.Won += () => Won?.Invoke();
            _victoryCondition.Lost += () => Lost?.Invoke();
        }

        public void Dispose()
        {
            _victoryCondition.Won -= () => Won?.Invoke();
            _victoryCondition.Lost -= () => Lost?.Invoke();
        }

        public void SetVictoryCondition(IGameOverCondition victoryCondition)
            => _victoryCondition = victoryCondition;
    }
}
