using System;
using Zenject;

namespace sceneloader
{
    public class SceneLoadMediator
    {
        private SceneLoader _sceneLoader;

        private IGameOverCondition _victoryCondition;

        [Inject]
        public SceneLoadMediator(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void GoToGameplayLevel(IGameOverCondition victoryCondition)
        {
            _victoryCondition = victoryCondition;
            _sceneLoader.Load(victoryCondition);
        }

        public void RestartGameplayLevel()
        {
            if (_victoryCondition == null)
                throw new NullReferenceException(nameof(_victoryCondition));

            _sceneLoader.Load(_victoryCondition);
        }

        public void GoToMainMenu()
            => _sceneLoader.Load(SceneID.Menu);
    }
}