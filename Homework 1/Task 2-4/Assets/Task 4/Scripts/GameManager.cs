using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsPlaying;

    [SerializeField] private GameObject _gameModePanel;
    [SerializeField] private Button _firstModeButton, _secondModeButton;
    private IVictoryChecker _victoryCondition;
    private EnemySpawner _enemySpawner;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Start()
    {
        _enemySpawner = EnemySpawner.Instance;
    }

    private void Update()
    {
        if (_victoryCondition == null)
            return;

        if (_victoryCondition.Win())
        {
            EndGame(true);
        }
        else if (_victoryCondition.Lose())
        {
            EndGame(false);
        }
    }

    public void StartGame()
    {
        IsPlaying = true;
        _enemySpawner.SpawnBalls();
    }

    public void SetVictoryCondition(IVictoryChecker victoryCondition)
    {
        _victoryCondition = victoryCondition;
    }

    private void EndGame(bool hasWon)
    {
        IsPlaying = false;

        UIHandler.Instance.ShowEndPanel(hasWon);

        Invoke("ReloadScene", 3f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
