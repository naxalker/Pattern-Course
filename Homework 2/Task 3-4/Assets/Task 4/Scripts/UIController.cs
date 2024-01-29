using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;

    public void UpdateLevelText(int level)
    {
        level = Mathf.Max(0, level);

        _levelText.text = "Уровень: " + level;
    }
}
