using UnityEngine;

[CreateAssetMenu(menuName = "Configs/CharacterConfig", fileName = "CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private RunningStateConfig _runningStateConfig;
    [SerializeField] private WalkingStateConfig _walkingStateConfig;
    [SerializeField] private FastRunningStateConfig _fastRunningStateConfig;
    [SerializeField] private AirbornStateConfig _airbornStateConfig;

    public RunningStateConfig RunningStateConfig => _runningStateConfig;
    public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
    public FastRunningStateConfig FastRunningStateConfig => _fastRunningStateConfig;
    public AirbornStateConfig AirbornStateConfig => _airbornStateConfig;
}
