using UnityEngine.InputSystem;

public class RunningState : GroundedState
{
    private readonly RunningStateConfig _config;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        View.StartRunning();

        Data.Speed = _config.Speed;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();

        Input.Movement.SpeedUp.started += OnSpeedUpKeyPressed;
        Input.Movement.SlowDown.started += OnSlowDownKeyPressed;
    }
    
    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();

        Input.Movement.SpeedUp.started -= OnSpeedUpKeyPressed;
        Input.Movement.SlowDown.started -= OnSlowDownKeyPressed;
    }

    private void OnSpeedUpKeyPressed(InputAction.CallbackContext context) => StateSwitcher.SwitchState<FastRunningState>();

    private void OnSlowDownKeyPressed(InputAction.CallbackContext context) => StateSwitcher.SwitchState<WalkingState>();
}
