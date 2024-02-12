using System;
using Zenject;

public class GameplayMediator : IInitializable, IDisposable
{
    private DefeatPanel _defeatPanel;

    private Level _level;

    public GameplayMediator(Level level, DefeatPanel defeatPanel)
    {
        _defeatPanel = defeatPanel;
        _level = level;
    }

    public void Initialize()
    {
        _defeatPanel.RestartClicked += OnRestartClicked;
        _level.Defeat += OnLevelDefeat;
    }

    public void Dispose()
    {
        _defeatPanel.RestartClicked -= OnRestartClicked;
        _level.Defeat -= OnLevelDefeat;
    }

    private void OnLevelDefeat() => _defeatPanel.Show();

    private void OnRestartClicked()
    {
        _defeatPanel.Hide();
        _level.Restart();
    }
}
