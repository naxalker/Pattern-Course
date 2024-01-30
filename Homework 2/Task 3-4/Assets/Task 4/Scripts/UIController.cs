using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private PlayerStatsMediator _playerStatMediator;

    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartClick);
    }

    public void UpdateLevelText(int level)
    {
        level = Mathf.Max(0, level);

        _levelText.text = "Уровень: " + level;
    }
    
    public void UpdateHealthBar(float value)
    {
        value = Mathf.Clamp01(value);

        _healthBar.value = value;
    }

    public void ShowRestartButton() => _restartButton.gameObject.SetActive(true);

    public void HideRestartButton() => _restartButton.gameObject.SetActive(false);

    private void OnRestartClick() => _playerStatMediator.Restart();
}
