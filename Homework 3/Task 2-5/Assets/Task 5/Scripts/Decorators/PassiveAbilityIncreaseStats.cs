using System;

public class PassiveAbilityIncreaseStats : StatProvider
{
    public PassiveAbilityIncreaseStats(StatProvider statProvider, 
                                       PassiveAbilityType passiveAbility, 
                                       PassiveAbilityStatsIncreseConfig config)
    {
        switch (passiveAbility)
        {
            case PassiveAbilityType.Strongman:
                Stats = statProvider.Stats + config.StrongmanIncrease;
                break;

            case PassiveAbilityType.Intellectual:
                Stats = statProvider.Stats + config.IntellectualIncrease;
                break;

            case PassiveAbilityType.Dodger:
                Stats = statProvider.Stats + config.DodgerIncrease;
                break;

            default:
                throw new ArgumentException(nameof(passiveAbility));
        }
    }

    public override CharacterStats Stats { get; }
}
