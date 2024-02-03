using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    public void Initialize(Material material)
    {
        _meshRenderer.sharedMaterial = material;
    }
}
