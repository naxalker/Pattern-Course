using Assets.Visitor;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private Score _score;
    private Weight _weight;
    
    private void Awake()
    {
        _score = new Score(_spawner);
        _weight = new Weight(_spawner, _spawner);
        _spawner.Initialize(_weight);
        _spawner.StartWork();
    }
}
