using UnityEngine;

public class MultishotWeapon : Weapon
{
    private int MaxNumberOfBulletsPerShot = 3;

    [SerializeField] private int _numberOfBullets;
    [SerializeField] private float _distanceBetweenBullets;

    protected override void Shoot()
    {
        if (_numberOfBullets <= 0)
            return;

        int bulletsToRelease = Mathf.Min(MaxNumberOfBulletsPerShot, _numberOfBullets);

        Vector3 spawnPosition = BulletSpawnPoint.position - 
            new Vector3((bulletsToRelease - 1) / 2f * _distanceBetweenBullets, 0f, 0f);

        for (int i = 0; i < bulletsToRelease; i++)
        {
            GameObject bullet = Instantiate(Bullet, spawnPosition, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;

            spawnPosition += new Vector3(_distanceBetweenBullets, 0f, 0f);

            Destroy(bullet, SecondsUntilDestroyBullet);
        }

        _numberOfBullets -= bulletsToRelease;
    }

    public override void UpdateAmmoText()
    {
        UIController.Instance.UpdateDisplay(_numberOfBullets.ToString());
    }
}
