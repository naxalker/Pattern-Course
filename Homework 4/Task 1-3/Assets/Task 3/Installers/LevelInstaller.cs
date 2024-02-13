using UnityEngine;
using Zenject;

namespace sceneloader
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private BallFactory _factory;
        [SerializeField] private BallsSpawnerConfig _config;

        [SerializeField] private LevelUI _levelUI;

        public override void InstallBindings()
        {
            BindSpawner();
            BindLevelMediator();
        }

        private void BindLevelMediator()
        {
            Container.BindInstance(_levelUI).AsSingle();
            Container.BindInterfacesAndSelfTo<Level>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelUIMediator>().AsSingle();
        }

        private void BindSpawner()
        {
            Container.BindInstance(_factory).AsSingle();
            Container.BindInstance(_config).AsSingle();
            Container.Bind<BallsSpawner>().AsSingle();
        }
    }
}