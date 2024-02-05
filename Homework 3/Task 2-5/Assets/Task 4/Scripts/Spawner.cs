using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Visitor
{
    public class Spawner: MonoBehaviour, IEnemyDeathNotifier, IEnemySpawnNotifier
    {
        private const int MaxEnemyWeight = 10;

        public event Action<Enemy> DeathNotified;
        public event Action<Enemy> SpawnNotified;

        [SerializeField] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;

        private Coroutine _spawn;

        private List<Enemy> _spawnedEnemies = new List<Enemy>();

        private Weight _weight;

        public void Initialize(Weight weight)
        {
            _weight = weight;
        }

        public void StartWork()
        {
            StopWork();

            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);
        }

        [ContextMenu("Kill")]
        public void KillRandomEnemy()
        {
            if (_spawnedEnemies.Count == 0)
                return;

            _spawnedEnemies[Random.Range(0, _spawnedEnemies.Count)].Kill();
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (_weight.Value >= MaxEnemyWeight)
                    break;

                Enemy enemy = _enemyFactory.Get((EnemyType)Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
                enemy.MoveTo(_spawnPoints[Random.Range(0, _spawnPoints.Count)].position);
                enemy.Died += OnEnemyDied;

                SpawnNotified?.Invoke(enemy);

                _spawnedEnemies.Add(enemy);

                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            enemy.Died -= OnEnemyDied;
            DeathNotified?.Invoke(enemy);
            _spawnedEnemies.Remove(enemy);
        }
    }
}
