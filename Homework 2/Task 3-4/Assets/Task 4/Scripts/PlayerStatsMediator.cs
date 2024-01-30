using UnityEngine;

public class PlayerStatsMediator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private UIController _controller;

    public void Initialize()
    {
        _player.Inited += OnInited;
        _player.Died += OnDied;
        _player.LeveledUp += OnLeveledUp;
        _player.AppliedDamage += OnAppliedDamage;
    }

    private void OnDestroy()
    {
        _player.Inited -= OnInited;
        _player.Died -= OnDied;
        _player.LeveledUp -= OnLeveledUp;
        _player.AppliedDamage -= OnAppliedDamage;
    }

    public void Restart()
    {
        _controller.HideRestartButton();
        _player.Restart();
    }

    private void OnInited(int health, int maxHealth, int level)
    {
        _controller.UpdateHealthBar((float)health / maxHealth);
        _controller.UpdateLevelText(level);
    }

    private void OnDied() => _controller.ShowRestartButton();

    private void OnLeveledUp(int level) => _controller.UpdateLevelText(level);

    private void OnAppliedDamage(int health, int maxHealth) => _controller.UpdateHealthBar((float)health / maxHealth);
}
