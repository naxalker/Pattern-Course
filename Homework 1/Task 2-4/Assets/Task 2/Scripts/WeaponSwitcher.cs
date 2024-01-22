using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> _weapons;
    private int _activeWeapon;

    private void Start()
    {
        _weapons[_activeWeapon].GetComponent<Weapon>().UpdateAmmoText();
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            SwitchWeapon();
    }

    private void SwitchWeapon()
    {
        _weapons[_activeWeapon].SetActive(false);

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (++_activeWeapon == _weapons.Count)
                _activeWeapon = 0;

            _weapons[_activeWeapon].SetActive(true);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (--_activeWeapon == -1)
                _activeWeapon = _weapons.Count - 1;

            _weapons[_activeWeapon].SetActive(true);
        }

        _weapons[_activeWeapon].GetComponent<Weapon>().UpdateAmmoText();
    }
}
