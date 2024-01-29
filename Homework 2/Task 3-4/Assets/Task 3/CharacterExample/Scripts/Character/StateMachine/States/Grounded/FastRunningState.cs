using UnityEngine;
using UnityEngine.InputSystem;

public class FastRunningState : GroundedState
{
    private FastRunningStateConfig _config;

    public FastRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.FastRunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed *= _config.SpeedModifier;
        Debug.Log(Data.Speed);
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

        //if (Input.Movement.SpeedUp.WasReleasedThisFrame())
        //    StateSwitcher.SwitchState<RunningState>();
    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();

        Input.Movement.SpeedUp.canceled += OnSpeedUpKeyReleased;
    }


    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();

        Input.Movement.SpeedUp.canceled -= OnSpeedUpKeyReleased;
    }

    private void OnSpeedUpKeyReleased(InputAction.CallbackContext context) => StateSwitcher.SwitchState<RunningState>();
}
