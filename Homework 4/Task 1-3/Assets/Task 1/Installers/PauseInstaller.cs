using Zenject;

public class PauseInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PauseHandler>().AsSingle();
    }
}
