using System;
using UnityEngine;

[Serializable]
public class BaseStatsConfig
{
    [field: SerializeField] public CharacterStats HumanBaseStats { get; private set; }
    [field: SerializeField] public CharacterStats OrkBaseStats { get; private set; }
    [field: SerializeField] public CharacterStats ElfBaseStats { get; private set; }
}
