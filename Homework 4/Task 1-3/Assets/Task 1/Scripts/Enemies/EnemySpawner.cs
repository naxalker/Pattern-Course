using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : IPause
{
    private EnemyFactory _enemyFactory;
    private EnemySpawnerConfig _config;

    private Coroutine _spawn;
    private AsyncProcessor _asyncProcessor;

    private bool _isPaused;

    public EnemySpawner(EnemyFactory enemyFactory, EnemySpawnerConfig config, PauseHandler pauseHandler, AsyncProcessor asyncProcessor)
    {
        _enemyFactory = enemyFactory;
        _config = config;
        _asyncProcessor = asyncProcessor;
        pauseHandler.Add(this);
    }

    public void StartWork()
    {
        StopWork();

        _spawn = _asyncProcessor.StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
            _asyncProcessor.StopCoroutine(_spawn);
    }

    public void SetPause(bool isPause) => _isPaused = isPause;

    private IEnumerator Spawn()
    {
        float time = 0;

        while (true)
        {
            while (time < _config.SpawnCooldown)
            {
                if(_isPaused == false)
                    time += Time.deltaTime;

                yield return null;
            }

            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_config.SpawnPoints[UnityEngine.Random.Range(0, _config.SpawnPoints.Count)].position);
            time = 0;
        }
    }
}
