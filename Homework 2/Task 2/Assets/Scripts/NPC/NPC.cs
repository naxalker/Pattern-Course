using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private NPCConfig _config;
    [Space]
    [SerializeField] private Transform _workingPlace;
    [SerializeField] private Transform _restingPlace;
    [Space]
    [SerializeField] private NPCView _view;
    [Space]
    [SerializeField] private ActionProgressSlider _actionProgressSlider;

    private NPCStateMachine _stateMachine;

    public NPCConfig Config => _config;
    public Vector3 WorkingPosition => _workingPlace.position;
    public Vector3 RestingPosition => _restingPlace.position;
    public NPCView View => _view;
    public ActionProgressSlider ActionProgressSlider => _actionProgressSlider;

    private void Awake()
    {
        _view.Initialize();
        _actionProgressSlider.Initialize();
        _stateMachine = new NPCStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}
