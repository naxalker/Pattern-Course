using System;
using UnityEngine;

[Serializable]
public class CoinConfig
{
    [SerializeField] private Material _material;

    public Material Material => _material;
}
