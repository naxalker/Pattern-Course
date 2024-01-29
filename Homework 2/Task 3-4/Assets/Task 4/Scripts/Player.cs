using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action Defeat;
    public event Action<int> LevelUp;
    public event Action<int> CauseDamage;

    [SerializeField] private int _health;
    [SerializeField] private int _level;

    [NaughtyAttributes.Button("+1 Уровень")]
    public void IncreaseLevel()
    {
        _level++;
        LevelUp?.Invoke(_level);
    }

    public void DealDamage(int damage)
    {
        _health -= damage;
        CauseDamage?.Invoke(_health);

        if (_health <= 0)
            Defeat?.Invoke();
    }
}
