using System;
using UnityEngine;

[Serializable]
public class ResourceIconConfig
{
    [SerializeField] private Sprite _coinIcon;
    [SerializeField] private Sprite _energyIcon;

    public Sprite CoinIcon => _coinIcon;
    public Sprite EnergyIcon => _energyIcon;
}
