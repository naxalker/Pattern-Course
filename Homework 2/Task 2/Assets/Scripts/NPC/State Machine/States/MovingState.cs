using UnityEngine;

public class MovingState : ActionState
{
    private Vector3 _targetPosition;
    private NPC _npc;

    public MovingState(IStateSwitcher stateSwitcher, StateMachineData data, NPC npc) : base(stateSwitcher, data, npc)
        => _npc = npc;

    private MovingStateConfig Config => _npc.Config.MovingStateConfig;
    private Vector3 NPCPosition => _npc.transform.position;

    public override void Enter()
    {
        base.Enter();

        Debug.Log("»‰Û");

        if (StateSwitcher.PreviousState is WorkingState)
        {
            _targetPosition = _npc.RestingPosition;
        } else
        {
            _targetPosition = _npc.WorkingPosition;
        }

        Data.Speed = Config.Speed;

        View.StartMoving();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopMoving();
    }

    public override void Update()
    {
        base.Update();

        _npc.transform.position = Vector3.MoveTowards(NPCPosition, _targetPosition, Data.Speed * Time.deltaTime);

        _npc.transform.LookAt(_targetPosition);
        
        if (Vector3.Distance(NPCPosition, _targetPosition) < 0.1f)
        {
            if (StateSwitcher.PreviousState is WorkingState)
                StateSwitcher.SwitchState<RestingState>();
            else
                StateSwitcher.SwitchState<WorkingState>();
        }
    }
}
