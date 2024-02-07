using UnityEngine;

public class CharacterBootstrap : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private StatsConfig _statsConfig;

    private void Awake()
    {
        _character.Initialize(_statsConfig);
    }
}
