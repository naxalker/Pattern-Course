using System;
using UnityEngine;
using UnityEngine.UI;

public class IconsController : MonoBehaviour
{
    [SerializeField] private UIContextType _contextType;
    [SerializeField] private IconFactoryConfig _iconFactoryConfig;
    [SerializeField] private Image _coinImage, _energyImage;

    [ContextMenu("Update")]
    public void UpdateIcons()
    {
        ResourceIconFactory iconFactory;

        switch (_contextType)
        {
            case UIContextType.Menu:
                iconFactory = new MenuIconFactory(_iconFactoryConfig);
                break;

            case UIContextType.Shop:
                iconFactory = new ShopIconFactory(_iconFactoryConfig);
                break;

            default:
                throw new ArgumentException(nameof(_contextType));
        }

        _coinImage.sprite = iconFactory.Get(ResourceType.Coin);
        _energyImage.sprite = iconFactory.Get(ResourceType.Energy);
    }
}
