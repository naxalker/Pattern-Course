using System;

public class BaseStats : StatProvider
{
    public BaseStats(RaceType race, BaseStatsConfig config)
    {
        switch (race)
        {
            case RaceType.Human:
                Stats = config.HumanBaseStats;
                break;

            case RaceType.Ork:
                Stats = config.OrkBaseStats;
                break;

            case RaceType.Elf:
                Stats = config.ElfBaseStats;
                break;

            default:
                throw new ArgumentException(nameof(race));
        }
    }

    public override CharacterStats Stats { get; }
}
