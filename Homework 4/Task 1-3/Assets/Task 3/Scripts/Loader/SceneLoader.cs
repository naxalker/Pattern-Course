using System;

namespace sceneloader
{
    public class SceneLoader
    {
        private ZenjectSceneLoaderWrapper _zenjectSceneLoader;

        public SceneLoader(ZenjectSceneLoaderWrapper zenjectSceneLoader)
        {
            _zenjectSceneLoader = zenjectSceneLoader;
        }

        public void Load(IGameOverCondition victoryCondition)
        {
            _zenjectSceneLoader.Load(container =>
            {
                container.BindInstance(victoryCondition);
            }, (int)SceneID.Gameplay);
        }

        public void Load(SceneID sceneID)
        {
            if (sceneID == SceneID.Gameplay)
                throw new ArgumentException(nameof(sceneID));

            _zenjectSceneLoader.Load(null, (int)sceneID);
        }
    }
}