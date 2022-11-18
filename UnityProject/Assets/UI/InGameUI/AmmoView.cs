using UnityEngine.Events;
using Weapons;

public class AmmoView : ValueText
{
    private UnityEvent<int> _ammoCountChange;

    public void OnWeaponTake(Weapon weapon)
    {
        if (weapon is IReloadeble == false)
        {
            return;
        }
        IReloadeble realoadebleWeapon = (IReloadeble)weapon;
        _ammoCountChange = realoadebleWeapon.AmmoCountChanged;
        _ammoCountChange.RemoveAllListeners();
        _ammoCountChange.AddListener(OnCorrentChanged);
    }

    public void OnWeaponDrop()
    {
        _ammoCountChange = null;
    }
}
