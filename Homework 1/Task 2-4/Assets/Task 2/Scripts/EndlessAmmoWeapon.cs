using UnityEngine;

public class EndlessAmmoWeapon : Weapon
{
    protected override void Shoot()
    {
        GameObject bullet = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;

        Destroy(bullet, SecondsUntilDestroyBullet);
    }

    public override void UpdateAmmoText()
    {
        UIController.Instance.UpdateDisplay("∞");
    }
}
