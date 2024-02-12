using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace sceneloader
{
    public class Level : ITickable
    {
        public event Action Won;
        public event Action Lost;

        private IVictoryCondition _victoryCondition;

        private BallsSpawner _spawner;

        public Level(BallsSpawner spawner)
        {
            _spawner = spawner;
        }

        public BallsSpawner Spawner => _spawner;

        public void Tick()
        {
            if (_victoryCondition == null)
                return;

            if (_victoryCondition.HasWon())
            {
                ProcessGameOver(true);
            }
            else if (_victoryCondition.HasLost())
            {
                ProcessGameOver(false);
            }
        }

        public void SetVictoryCondition(IVictoryCondition victoryCondition)
            => _victoryCondition = victoryCondition;

        public void StartLevel()
        {
            _spawner.SpawnBalls();
        }

        private void ProcessGameOver(bool hasWon)
        {
            if (hasWon)
                Won?.Invoke();
            else
                Lost?.Invoke();
        }
    }
}
