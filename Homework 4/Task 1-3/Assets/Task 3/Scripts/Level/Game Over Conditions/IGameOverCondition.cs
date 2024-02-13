using System;
using System.Collections.Generic;

namespace sceneloader
{
    public interface IGameOverCondition
    {
        event Action Won;
        event Action Lost;

        void Initialize(List<Ball> spawnedBalls);
    }
}