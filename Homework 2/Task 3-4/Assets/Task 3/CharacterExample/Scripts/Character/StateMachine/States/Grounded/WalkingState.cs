using UnityEngine.InputSystem;

public class WalkingState : GroundedState
{
    private WalkingStateConfig _config;

    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.WalkingStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed *= _config.SpeedModifier;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();

        //if (Input.Movement.SlowDown.WasReleasedThisFrame())
        //    StateSwitcher.SwitchState<RunningState>();
    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();

        Input.Movement.SlowDown.canceled += OnSlowDownKeyReleased;
    }

    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();

        Input.Movement.SlowDown.canceled -= OnSlowDownKeyReleased;
    }

    private void OnSlowDownKeyReleased(InputAction.CallbackContext context) => StateSwitcher.SwitchState<RunningState>();
}
