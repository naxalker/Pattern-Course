using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace sceneloader
{
    public class BallsSpawner
    {
        private const float SpawnBound = 6f;
        private const float SpawnHeight = 6f;

        private BallsSpawnerConfig _config;
        private BallFactory _factory;

        private List<Ball> _spawnedBalls = new List<Ball>();

        public BallsSpawner(BallsSpawnerConfig config, BallFactory factory)
        {
            _config = config;
            _factory = factory;
        }

        public List<Ball> SpawnedBalls => _spawnedBalls;

        public void SpawnBalls()
        {
            _spawnedBalls.Clear();

            for (int i = 0; i < _config.BallsCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-SpawnBound, SpawnBound),
                                                    SpawnHeight + Random.Range(-1f, 1f),
                                                    Random.Range(-SpawnBound, SpawnBound));

                BallType ballType = (BallType)Random.Range(0, Enum.GetValues(typeof(BallType)).Length);
                Ball ball = _factory.Get(ballType);
                ball.transform.position = spawnPosition;
                ball.Popped += OnBallPopped;

                _spawnedBalls.Add(ball.GetComponent<Ball>());
            }
        }

        private void OnBallPopped(Ball ball)
        {
            _spawnedBalls.Remove(ball);
            ball.Popped -= OnBallPopped;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(new Vector3(0f, SpawnHeight, 0f),
                new Vector3(2 * SpawnBound, 0f, 2 * SpawnBound));
        }
    }
}
