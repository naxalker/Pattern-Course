using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SecondModeVictoryChecker : IVictoryChecker
{
    private Material _targetMaterial;
    private int _originNonTargetedBallsCount;
    private List<Ball> _balls;

    public SecondModeVictoryChecker(Material targetMaterial)
    {
        _targetMaterial = targetMaterial;

        _balls = EnemySpawner.Instance.SpawnedBalls;
        _originNonTargetedBallsCount = _balls
            .Where(ball => ball.GetComponent<MeshRenderer>().sharedMaterial != _targetMaterial)
            .Count();
    }

    public bool Lose()
    {
        List<Ball> nonTargetedBalls = new List<Ball>(_balls
            .Where(ball => ball.GetComponent<MeshRenderer>().sharedMaterial != _targetMaterial));

        return nonTargetedBalls.Count != _originNonTargetedBallsCount;
    }

    public bool Win()
    {
        List<Ball> targetedBalls = new List<Ball>(_balls
            .Where(ball => ball.GetComponent<MeshRenderer>().sharedMaterial == _targetMaterial));

        return targetedBalls.Count == 0;
    }
}
