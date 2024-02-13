using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace sceneloader
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private Button _firstModeButton, _secondModeButton;

        private SceneLoadMediator _sceneLoadMediator;

        [Inject]
        private void Construct(SceneLoadMediator sceneLoadMediator)
        {
            _sceneLoadMediator = sceneLoadMediator;
        }

        private void OnEnable()
        {
            _firstModeButton.onClick.AddListener(OnFirstModeButtonClick);
            _secondModeButton.onClick.AddListener(OnSecondModeButtonClick);
        }

        private void OnDisable()
        {
            _firstModeButton.onClick.RemoveListener(OnFirstModeButtonClick);
            _secondModeButton.onClick.RemoveListener(OnSecondModeButtonClick);
        }

        private void OnFirstModeButtonClick()
        {
            _sceneLoadMediator.GoToGameplayLevel(new FirstModeVictoryCondition());
        }

        private void OnSecondModeButtonClick()
        {
            BallType targetBall = (BallType)Random.Range(0, Enum.GetValues(typeof(BallType)).Length);

            _sceneLoadMediator.GoToGameplayLevel(new SecondModeVictoryCondition(targetBall));
        }
    }
}