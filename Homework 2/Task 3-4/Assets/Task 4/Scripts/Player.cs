using NaughtyAttributes;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<int, int, int> Inited;
    public event Action Died;
    public event Action<int> LeveledUp;
    public event Action<int, int> AppliedDamage;

    [SerializeField] private int _initHealth;
    [SerializeField] private int _initLevel;
    private int _health, _maxHealth;
    private int _level;
    private bool isDead;

    public void Initialize()
    {
        _health = _maxHealth = _initHealth;
        _level = _initLevel;

        isDead = false;

        Inited?.Invoke(_health, _maxHealth, _level);
    }

    public void IncreaseLevel()
    {
        if (isDead)
            return;

        _level++;
        LeveledUp?.Invoke(_level);
    }
    
    public void ApplyDamage(int damage)
    {
        if (isDead)
            return;

        _health -= damage;
        AppliedDamage?.Invoke(_health, _maxHealth);

        if (_health <= 0)
        {
            isDead = true;
            Died?.Invoke();
        }
    }

    public void Restart()
    {
        Initialize();
    }

    [Button("+1 Уровень", enabledMode: EButtonEnableMode.Playmode)]
    private void DebugLevelUp()
    {
        IncreaseLevel();
    }

    [Button("-10 ХП", enabledMode: EButtonEnableMode.Playmode)]
    private void DebugApplyDamage()
    {
        ApplyDamage(10);
    }
}
