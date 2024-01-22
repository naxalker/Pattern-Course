using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    private float SpawnBound = 6f;
    private float SpawnHeight = 6f;

    [SerializeField] private int _ballsCount;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Material[] _ballMaterials;
    [SerializeField] private List<Ball> _spawnedBalls = new List<Ball>();

    public List<Ball> SpawnedBalls {
        get { return _spawnedBalls; }
    }
    public Material[] BallMaterials
    {
        get { return _ballMaterials; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnBalls()
    {
        _spawnedBalls.Clear();

        for (int i = 0; i < _ballsCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-SpawnBound, SpawnBound),
                                                SpawnHeight + Random.Range(-1f, 1f),
                                                Random.Range(-SpawnBound, SpawnBound));

            GameObject ball = Instantiate(_ballPrefab, spawnPosition, Quaternion.identity);
            ball.transform.localScale *= Random.Range(.8f, 1.2f);
            ball.GetComponent<MeshRenderer>().material = _ballMaterials[Random.Range(0, _ballMaterials.Length)];
            
            _spawnedBalls.Add(ball.GetComponent<Ball>());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector3(0f, SpawnHeight, 0f),
            new Vector3(2 * SpawnBound, 0f, 2 * SpawnBound));
    }
}
