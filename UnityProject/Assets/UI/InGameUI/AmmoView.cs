using UnityEngine;
using UnityEngine.Events;
using Weapons;

public class AmmoView : ValueText
{
    private UnityEvent<int> _ammoCountChange;

    public void OnWeaponTake(Weapon weapon)
    {
        IReloadeble reloadebleWeapon;
        if (weapon is IReloadeble == false)
        {
            Text.gameObject.SetActive(false);
            return;
        }
        Text.gameObject.SetActive(true);
        reloadebleWeapon = (IReloadeble)weapon;
        _ammoCountChange = reloadebleWeapon.AmmoCountChanged;
        _ammoCountChange.RemoveAllListeners();
        _ammoCountChange.AddListener(OnCorrentChanged);
        SetValue(reloadebleWeapon.AmmoCount);
    }

    public void OnWeaponDrop()
    {
        _ammoCountChange = null;
        Text.gameObject.SetActive(false);
    }
}
