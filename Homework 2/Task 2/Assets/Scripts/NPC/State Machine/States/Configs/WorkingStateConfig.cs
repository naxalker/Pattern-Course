using System;
using UnityEngine;

[Serializable]
public class WorkingStateConfig
{
    [SerializeField, Range(0f, 100f)] private float _workingDuration;

    public float WorkingDuration => _workingDuration;
}
