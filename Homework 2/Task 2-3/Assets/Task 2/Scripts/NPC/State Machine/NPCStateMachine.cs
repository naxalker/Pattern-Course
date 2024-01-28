using System.Collections.Generic;
using System.Linq;

public class NPCStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;
    private IState _previousState;

    public NPCStateMachine(NPC npc)
    {
        StateMachineData data = new StateMachineData();

        _states = new List<IState>()
        {
            new MovingState(this, data, npc),
            new WorkingState(this, data, npc),
            new RestingState(this, data, npc),
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public IState PreviousState => _previousState;

    public void SwitchState<T>() where T : IState
    {
        _previousState = _currentState;

        IState state = _states.FirstOrDefault(state => state is T);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
}
