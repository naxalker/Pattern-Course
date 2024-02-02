using UnityEngine;

[CreateAssetMenu(fileName = "IconFactoryConfig", menuName = "Factory/IconFactoryConfig")]
public class IconFactoryConfig : ScriptableObject
{
    [SerializeField] private ResourceIconConfig _menuIconsConfig;
    [SerializeField] private ResourceIconConfig _shopIconsConfig;

    public ResourceIconConfig MenuIconsConfig => _menuIconsConfig;
    public ResourceIconConfig ShopIconsConfig => _shopIconsConfig;
}
