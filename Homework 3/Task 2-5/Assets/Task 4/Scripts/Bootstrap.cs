using Assets.Visitor;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private Score _score;
    
    private void Awake()
    {
        _spawner.StartWork();
        _score = new Score(_spawner);
    }
}
