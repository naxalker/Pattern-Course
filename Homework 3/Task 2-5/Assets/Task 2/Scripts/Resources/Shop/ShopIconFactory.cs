using System;
using UnityEngine;

public class ShopIconFactory : ResourceIconFactory
{
    private ResourceIconConfig _config;
    public ShopIconFactory(IconFactoryConfig config) : base(config)
        => _config = Config.ShopIconsConfig;

    public override Sprite Get(ResourceType type)
    {
        switch (type)
        {
            case ResourceType.Coin:
                return _config.CoinIcon;

            case ResourceType.Energy:
                return _config.EnergyIcon;

            default:
                throw new ArgumentException(nameof(type));
        }
    }
}
