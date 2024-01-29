using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsMediator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private UIController _controller;

    private void Awake()
    {
        _player.LevelUp += OnLevelIncreased;
    }

    private void OnDestroy()
    {
        _player.LevelUp -= OnLevelIncreased;
    }

    private void OnLevelIncreased(int level) => _controller.UpdateLevelText(level);
}
