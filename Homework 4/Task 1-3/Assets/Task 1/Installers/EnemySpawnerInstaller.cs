using System;
using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    [SerializeField] private EnemySpawnerConfig _config;

    public override void InstallBindings()
    {
        BindFactory();
        BindConfig();
        BindAsyncProcessor();

        BindSpawner();
    }

    private void BindSpawner()
    {
        Container.Bind<EnemySpawner>().AsSingle().NonLazy();
    }

    private void BindAsyncProcessor()
    {
        Container.Bind<AsyncProcessor>().FromNewComponentOnNewGameObject().AsSingle();
    }

    private void BindFactory()
    {
        Container.Bind<EnemyFactory>().AsSingle();
    }

    private void BindConfig()
    {
        Container.Bind<EnemySpawnerConfig>().FromInstance(_config).AsSingle();
    }
}
