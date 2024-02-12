using sceneloader;
using UnityEngine;

[CreateAssetMenu(fileName = "BallsSpawnerConfig", menuName = "Configs/BallsSpawnerConfig")]
public class BallsSpawnerConfig : ScriptableObject
{
    [SerializeField] private int _ballsCount;

    public int BallsCount => _ballsCount;
}
