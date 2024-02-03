using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private CoinFactory _coinFactory;

    private List<Transform> _availableSpawnPoints, _unavailableSpawnPoints;

    private void Awake()
    {
        _availableSpawnPoints = new List<Transform>(_spawnPoints);
        _unavailableSpawnPoints = new List<Transform>();
    }

    [ContextMenu("Spawn")]
    public void SpawnRandomCoin()
    {
        if (_availableSpawnPoints.Count == 0)
            return;

        CoinType coinType = (CoinType)Random.Range(0, Enum.GetValues(typeof(CoinType)).Length);
        Coin coin = _coinFactory.Get(coinType);

        Transform spawnPoint = _availableSpawnPoints[Random.Range(0, _availableSpawnPoints.Count)];
        _availableSpawnPoints.Remove(spawnPoint);
        _unavailableSpawnPoints.Add(spawnPoint);

        coin.transform.position = spawnPoint.position;
    }
}
