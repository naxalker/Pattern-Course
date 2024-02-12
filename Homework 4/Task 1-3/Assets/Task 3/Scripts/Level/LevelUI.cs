using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace sceneloader
{
    public class LevelUI : MonoBehaviour
    {
        public event Action ModeSelected;
        public event Action FirstModeSelected;
        public event Action SecondModeSelected;

        [SerializeField] private GameObject _startPanel, _endPanel, _colorPanel;
        [SerializeField] private Button _firstModeButton, _secondModeButton;

        private void OnEnable()
        {
            _firstModeButton.onClick.AddListener(OnButtonClick);
            _secondModeButton.onClick.AddListener(OnButtonClick);

            _firstModeButton.onClick.AddListener(OnFirstModeButtonClick);

            _secondModeButton.onClick.AddListener(OnSecondModeButtonClick);
        }

        public void ShowEndPanel(bool hasWon)
        {
            _endPanel.SetActive(true);
            _endPanel.GetComponentInChildren<TextMeshProUGUI>().text = hasWon ? "Победа!" : "Поражение...";
        }

        public void SetTargetColor(Color targetColor)
            => _colorPanel.GetComponentInChildren<Image>().color = targetColor;

        private void OnButtonClick()
        {
            _startPanel.SetActive(false);
            ModeSelected?.Invoke();
        }

        private void OnFirstModeButtonClick() => FirstModeSelected?.Invoke();

        private void OnSecondModeButtonClick()
        {
            _colorPanel.SetActive(true);

            SecondModeSelected?.Invoke();
        }
    }
}