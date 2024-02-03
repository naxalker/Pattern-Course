using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinFactory", menuName = "Factory/CoinFactory")]
public class CoinFactory : ScriptableObject
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private CoinConfig _bronzeCoin, _silverCoin, _goldCoin;

    public Coin Get(CoinType coinType)
    {
        CoinConfig config = GetConfig(coinType);
        Coin instance = Instantiate(_coinPrefab);
        instance.Initialize(config.Material);

        return instance;
    }

    private CoinConfig GetConfig(CoinType coinType)
    {
        switch (coinType)
        {
            case CoinType.Bronze:
                return _bronzeCoin;

            case CoinType.Silver:
                return _silverCoin;

            case CoinType.Gold: 
                return _goldCoin;

            default:
                throw new ArgumentException(nameof(coinType));
        }
    }
}
