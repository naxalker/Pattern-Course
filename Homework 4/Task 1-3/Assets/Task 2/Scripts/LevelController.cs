using UnityEngine;
using Zenject;

public class LevelController : IInitializable, ITickable
{
    private Level _level;

    public LevelController(Level level)
    {
        _level = level;
    }

    public void Initialize()
    {
        _level.Start();
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _level.OnDefeat();
        }
    }
}
