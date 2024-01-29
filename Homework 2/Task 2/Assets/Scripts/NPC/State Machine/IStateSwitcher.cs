public interface IStateSwitcher
{
    IState PreviousState { get; }
    void SwitchState<T>() where T : IState;
}
