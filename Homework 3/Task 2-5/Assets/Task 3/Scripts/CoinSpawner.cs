using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private CoinFactory _coinFactory;

    private List<Transform> _availableSpawnPoints;
    private Dictionary<Coin, Transform> _occupiedSpawnPoints;

    private void Awake()
    {
        _availableSpawnPoints = new List<Transform>(_spawnPoints);
        _occupiedSpawnPoints = new Dictionary<Coin, Transform>();
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
        _occupiedSpawnPoints.Add(coin, spawnPoint);

        coin.transform.position = spawnPoint.position;
    }

    [ContextMenu("Remove")]
    public void RemoveRandomCoin()
    {
        if (_occupiedSpawnPoints.Count == 0)
            return;

        KeyValuePair<Coin, Transform> occupiedSpawnPoint = 
            _occupiedSpawnPoints.ElementAt(Random.Range(0, _occupiedSpawnPoints.Count));
        _occupiedSpawnPoints.Remove(occupiedSpawnPoint.Key);

        Coin coin = occupiedSpawnPoint.Key;
        Destroy(coin.gameObject);
        
        Transform spawnPoint = occupiedSpawnPoint.Value;
        _availableSpawnPoints.Add(spawnPoint);
    }
}
