using UnityEngine;

public class StandardWeapon : Weapon
{
    [SerializeField] private int _numberOfBullets;

    protected override void Shoot()
    {
        if (_numberOfBullets <= 0)
            return;

        GameObject bullet = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;

        _numberOfBullets--;

        Destroy(bullet, SecondsUntilDestroyBullet);
    }

    public override void UpdateAmmoText()
    {
        UIController.Instance.UpdateDisplay(_numberOfBullets.ToString());
    }
}
