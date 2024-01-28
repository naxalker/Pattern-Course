public abstract class ActionState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    private readonly NPC _npc;

    public ActionState(IStateSwitcher stateSwitcher, StateMachineData data, NPC npc)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _npc = npc;
    }

    protected NPCView View => _npc.View;
    protected ActionProgressSlider ActionProgressSlider => _npc.ActionProgressSlider;

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
    }
}
