using System;
using UnityEngine;

[Serializable]
public class SpecStatsModifierConfig
{
    [field: SerializeField] public float BarbarianModifier { get; private set; }
    [field: SerializeField] public float MagicianModifier { get; private set; }
    [field: SerializeField] public float ThiefModifier { get; private set; }
}
