using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public static UIHandler Instance;

    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private GameObject _colorPanel;
    private GameManager _gameManager;
    private EnemySpawner _enemySpawner;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _enemySpawner = EnemySpawner.Instance;

        _startPanel.SetActive(true);
    }

    public void ShowEndPanel(bool hasWon)
    {
        _endPanel.SetActive(true);
        _endPanel.GetComponentInChildren<TextMeshProUGUI>().text = hasWon ? "Победа!" : "Поражение...";
    }

    public void ProcessFirstModeButtonPress()
    {
        _startPanel.SetActive(false);
        _gameManager.StartGame();
        _gameManager.SetVictoryCondition(new FirstModeVictoryChecker());
    }

    public void ProcessSecondModeButtonPress()
    {
        _startPanel.SetActive(false);
        _gameManager.StartGame();

        Material targetMaterial = _enemySpawner.BallMaterials[Random.Range(0, _enemySpawner.BallMaterials.Length)];
        DisplayTargetColor(targetMaterial.color);
        _gameManager.SetVictoryCondition(new SecondModeVictoryChecker(targetMaterial));
    }

    private void DisplayTargetColor(Color targetColor)
    {
        _colorPanel.SetActive(true);
        _colorPanel.GetComponentInChildren<Image>().color = targetColor;
    }
}
