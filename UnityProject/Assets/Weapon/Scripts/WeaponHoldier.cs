using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Weapons 
{
    public class WeaponHoldier : MonoBehaviour
    {
        [Header("Weapon holdier")]
        [SerializeField] private Weapon _currentWeapon;
        [SerializeField] private XPcontainer _owenerXPContainter;
        [SerializeField] private Transform _weaponHoldierTransform;
        [SerializeField] private UnityEvent<Weapon> _weaponPickUp;
        [SerializeField] private UnityEvent _weaponDrop;
        public Weapon CurrentWeapon => _currentWeapon;
        public bool CanShoot => _currentWeapon != null;

        public void OnEnable()
        {
            InputHandler.Singletone.WorldMovement.Shoot.started += Attack;
            InputHandler.Singletone.WorldMovement.Shoot.canceled += Attack;
            InputHandler.Singletone.WorldMovement.Shoot.performed += Attack;
            InputHandler.Singletone.WorldMovement.Reload.started += Reload;
            InputHandler.Singletone.WorldMovement.DropWeapon.started += DropWeapon;
        }

        public void OnDisable()
        {
            InputHandler.Singletone.WorldMovement.Shoot.started -= Attack;
            InputHandler.Singletone.WorldMovement.Shoot.canceled -= Attack;
            InputHandler.Singletone.WorldMovement.Shoot.performed -= Attack;
            InputHandler.Singletone.WorldMovement.Reload.started -= Reload;
            InputHandler.Singletone.WorldMovement.DropWeapon.started -= DropWeapon;
        }

        public void Attack(InputAction.CallbackContext context)
        {
            if (CanShoot)
            {
                _currentWeapon.Use(context.phase);
            }
        }

        public void Reload(InputAction.CallbackContext context)
        {
            Reload();
        }

        public void Reload()
        {
            if (_currentWeapon is IReloadeble)
            {
                ((IReloadeble)_currentWeapon)?.Reload();
            }
        }

        public void DropWeapon(InputAction.CallbackContext context)
        {
            DropWeapon();
        }

        public void DropWeapon()
        {
            if (_currentWeapon != null)
            {
                Shot.ClearInstances(_currentWeapon.ShotType);
                _currentWeapon.Drop();
                _currentWeapon = null;
            }
            _weaponDrop.Invoke();
        }

        public void PutWeapon(Weapon weapon) 
        {
            DropWeapon();
            _currentWeapon = weapon;
            weapon.PickUp(new OwnerInfo()
            {
                   transform = _weaponHoldierTransform,
                   xpContainer = _owenerXPContainter,
            });
            _weaponPickUp.Invoke(_currentWeapon);
        }
    }
}
