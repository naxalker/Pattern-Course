using System;

[Serializable]
public class CharacterStats
{
    public float Strength;
    public float Intelligence;
    public float Dexterity;

    public static CharacterStats operator +(CharacterStats stats1, CharacterStats stats2)
    {
        return new CharacterStats
        {
            Strength = stats1.Strength + stats2.Strength,
            Intelligence = stats1.Intelligence + stats2.Intelligence,
            Dexterity = stats1.Dexterity + stats2.Dexterity
        };
    }

    public static CharacterStats operator +(CharacterStats stats1, float increaseValue)
    {
        return new CharacterStats
        {
            Strength = stats1.Strength + increaseValue,
            Intelligence = stats1.Intelligence + increaseValue,
            Dexterity = stats1.Dexterity + increaseValue
        };
    }

    public static CharacterStats operator *(CharacterStats stats1, float modifier)
    {
        return new CharacterStats
        {
            Strength = stats1.Strength * modifier,
            Intelligence = stats1.Intelligence * modifier,
            Dexterity = stats1.Dexterity * modifier
        };
    }
}
