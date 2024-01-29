using UnityEngine;

public class WorkingState : ActionState
{
    private WorkingStateConfig _config;

    public WorkingState(IStateSwitcher stateSwitcher, StateMachineData data, NPC npc) : base(stateSwitcher, data, npc)
        => _config = npc.Config.WorkingStateConfig;

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Работаю");

        Data.WorkingTimer = _config.WorkingDuration;

        View.StartWorking();

        ActionProgressSlider.Show();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopWorking();

        ActionProgressSlider.Hide();
    }

    public override void Update()
    {
        base.Update();

        Data.WorkingTimer -= Time.deltaTime;

        ActionProgressSlider.Fill(1f - Data.WorkingTimer / _config.WorkingDuration);

        if (Data.WorkingTimer <= 0f)
            StateSwitcher.SwitchState<MovingState>();
    }
}
