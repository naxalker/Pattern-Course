using System;
using UnityEngine;

[Serializable]
public class RestingStateConfig
{
    [SerializeField, Range(0f, 100f)] private float _restingDuration;

    public float RestingDuration => _restingDuration;
}
