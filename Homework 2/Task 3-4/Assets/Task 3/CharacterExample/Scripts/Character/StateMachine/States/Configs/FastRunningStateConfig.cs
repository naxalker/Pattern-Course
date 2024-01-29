using System;
using UnityEngine;

[Serializable]
public class FastRunningStateConfig
{
    [SerializeField, Range(1f, 5f)] private float _speedModifier;

    public float SpeedModifier => _speedModifier;
}
