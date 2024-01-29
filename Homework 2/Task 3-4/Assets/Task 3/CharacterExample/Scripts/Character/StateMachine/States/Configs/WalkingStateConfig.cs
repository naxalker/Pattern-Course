using System;
using UnityEngine;

[Serializable]
public class WalkingStateConfig
{
    [SerializeField, Range(0f, 1f)] private float _speedModifier;

    public float SpeedModifier => _speedModifier;
}
