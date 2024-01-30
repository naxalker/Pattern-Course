using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerStatsMediator _playerStatMediator;
    [SerializeField] private UIController _controller;

    private void Awake()
    {
        _playerStatMediator.Initialize();
        _player.Initialize();
    }
}
