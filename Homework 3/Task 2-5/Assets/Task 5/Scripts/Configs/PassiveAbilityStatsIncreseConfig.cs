using System;
using UnityEngine;

[Serializable]
public class PassiveAbilityStatsIncreseConfig
{
    [field: SerializeField] public float StrongmanIncrease { get; private set; }
    [field: SerializeField] public float IntellectualIncrease { get; private set; }
    [field: SerializeField] public float DodgerIncrease { get; private set; }
}
