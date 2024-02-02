using UnityEngine;

public abstract class ResourceIconFactory
{
    private IconFactoryConfig _config;

    protected ResourceIconFactory(IconFactoryConfig config)
    {
        _config = config;
    }

    public IconFactoryConfig Config => _config;

    public abstract Sprite Get(ResourceType type);
}
