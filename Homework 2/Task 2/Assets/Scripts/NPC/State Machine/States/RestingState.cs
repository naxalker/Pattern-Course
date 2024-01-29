using UnityEngine;

public class RestingState : ActionState
{
    private RestingStateConfig _config;

    public RestingState(IStateSwitcher stateSwitcher, StateMachineData data, NPC npc) : base(stateSwitcher, data, npc)
        => _config = npc.Config.RestingStateConfig;

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Отдыхаю");

        Data.RestingTimer = _config.RestingDuration;

        View.StartResting();

        ActionProgressSlider.Show();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopResting();

        ActionProgressSlider.Hide();
    }

    public override void Update()
    {
        base.Update();

        Data.RestingTimer -= Time.deltaTime;

        ActionProgressSlider.Fill(1f - Data.RestingTimer / _config.RestingDuration);

        if (Data.RestingTimer <= 0f)
            StateSwitcher.SwitchState<MovingState>();
    }
}
