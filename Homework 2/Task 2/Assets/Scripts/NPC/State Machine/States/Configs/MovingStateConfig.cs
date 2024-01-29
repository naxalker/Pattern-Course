using System;
using UnityEngine;

[Serializable]
public class MovingStateConfig
{
    [SerializeField, Range(1f, 10f)] private float _speed;

    public float Speed => _speed;
}
