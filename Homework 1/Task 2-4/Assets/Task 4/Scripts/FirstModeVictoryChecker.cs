public class FirstModeVictoryChecker : IVictoryChecker
{
    public bool Lose() => false;

    public bool Win() => EnemySpawner.Instance.SpawnedBalls.Count == 0;
}
