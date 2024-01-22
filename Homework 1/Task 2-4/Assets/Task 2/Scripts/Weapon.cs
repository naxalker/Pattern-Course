using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected float SecondsUntilDestroyBullet = 5f;

    [SerializeField] protected GameObject Bullet;
    [SerializeField] protected Transform BulletSpawnPoint;
    [SerializeField] protected float BulletSpeed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            UpdateAmmoText();
        }
    }

    protected abstract void Shoot();

    public abstract void UpdateAmmoText();
}
