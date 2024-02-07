using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private RaceType _race;
    [SerializeField] private SpecType _spec;
    [SerializeField] private PassiveAbilityType _passiveAbility;

    private CharacterStats _stats;
    private StatsConfig _statsConfig;

    public void Initialize(StatsConfig statsConfig)
    {
        _statsConfig = statsConfig;

        UpdateStats();
    }

    [ContextMenu("Update")]
    public void UpdateStats()
    {
        BaseStats baseStats = new BaseStats(_race, _statsConfig.BaseStatsConfig);
        SpecModifierStats specModifierStats = new SpecModifierStats(baseStats, _spec, _statsConfig.SpecStatsModifierConfig);
        PassiveAbilityIncreaseStats passiveAbilityIncreaseStats =
            new PassiveAbilityIncreaseStats(specModifierStats, _passiveAbility, _statsConfig.PassiveAbilityStatsIncreaseConfig);

        _stats = passiveAbilityIncreaseStats.Stats;

        Debug.Log($"Мои статы: \nСила: {_stats.Strength} Интеллект: {_stats.Intelligence} Ловкость: {_stats.Dexterity}");
    }
}
