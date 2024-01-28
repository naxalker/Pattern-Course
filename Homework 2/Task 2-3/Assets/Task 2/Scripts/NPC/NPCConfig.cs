using UnityEngine;

[CreateAssetMenu(fileName = "NPCConfig", menuName = "Configs/NPCConfig")]
public class NPCConfig : ScriptableObject
{
    [SerializeField] private MovingStateConfig _movingStateConfig;
    [SerializeField] private RestingStateConfig _restingStateConfig;
    [SerializeField] private WorkingStateConfig _workingStateConfig;

    public MovingStateConfig MovingStateConfig => _movingStateConfig;
    public RestingStateConfig RestingStateConfig => _restingStateConfig;
    public WorkingStateConfig WorkingStateConfig => _workingStateConfig;
}
