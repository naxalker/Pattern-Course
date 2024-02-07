using System;

public class SpecModifierStats : StatProvider
{
    public SpecModifierStats(StatProvider statProvider, SpecType spec, SpecStatsModifierConfig config)
    {
        switch (spec)
        {
            case SpecType.Barbarian:
                Stats = statProvider.Stats * config.BarbarianModifier;
                break;

            case SpecType.Magician:
                Stats = statProvider.Stats * config.MagicianModifier;
                break;

            case SpecType.Thief:
                Stats = statProvider.Stats * config.ThiefModifier;
                break;

            default:
                throw new ArgumentException(nameof(spec));
        }
    }

    public override CharacterStats Stats { get; }
}
