using UnityEngine;

[CreateAssetMenu(fileName = "StatsConfig", menuName = "Configs/StatsConfig")]
public class StatsConfig : ScriptableObject
{
    [SerializeField] private BaseStatsConfig _baseStatsConfig;
    [SerializeField] private SpecStatsModifierConfig _specStatsModifierConfig;
    [SerializeField] private PassiveAbilityStatsIncreseConfig _passiveAbilityStatsIncreaseConfig;

    public BaseStatsConfig BaseStatsConfig => _baseStatsConfig;
    public SpecStatsModifierConfig SpecStatsModifierConfig => _specStatsModifierConfig;
    public PassiveAbilityStatsIncreseConfig PassiveAbilityStatsIncreaseConfig => _passiveAbilityStatsIncreaseConfig;
}
