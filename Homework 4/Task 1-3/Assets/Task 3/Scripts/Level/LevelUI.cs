using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace sceneloader
{
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel, _colorPanel;
        [SerializeField] private Button _menuButton, _restartButton;

        private SceneLoadMediator _sceneLoaderMediator;

        [Inject]
        public void Construct(SceneLoadMediator sceneLoaderMediator)
        {
            _sceneLoaderMediator = sceneLoaderMediator;
        }

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(OnMenuButtonClick);
            _restartButton.onClick.AddListener(OnRestartButtonClick);
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(OnMenuButtonClick);
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        }

        public void ShowGameOverPanel(bool hasWon)
        {
            _gameOverPanel.SetActive(true);
            _gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = hasWon ? "Победа!" : "Поражение...";
        }

        public void DisplayTargetColor(BallType ballType)
        {
            _colorPanel.SetActive(true);

            Color color;

            switch (ballType)
            {
                case BallType.Red:
                    color = Color.red;
                    break;

                case BallType.Yellow:
                    color = Color.yellow;
                    break;

                case BallType.Green:
                    color = Color.green;
                    break;

                default:
                    throw new ArgumentException(nameof(ballType));
            }

            _colorPanel.GetComponentInChildren<Image>().color = color;
        }

        private void OnMenuButtonClick()
            => _sceneLoaderMediator.GoToMainMenu();

        private void OnRestartButtonClick()
            => _sceneLoaderMediator.RestartGameplayLevel();
    }
}