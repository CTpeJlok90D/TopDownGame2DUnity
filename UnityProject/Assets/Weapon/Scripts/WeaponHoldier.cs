using UnityEngine;
using UnityEngine.InputSystem;
using Weapon;

namespace Weapons 
{
    public class WeaponHoldier : MonoBehaviour
    {
        [Header("Weapon holdier")]
        [SerializeField] private Weapon _currentWeapon;
        [SerializeField] private XPcontainer _owenerXPContainter;

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
            _currentWeapon?.Drop();
            if (_currentWeapon != null)
            {
                _currentWeapon.OwnerXpContainer = null;
            }
            _currentWeapon = null;
        }

        public void PutWeapon(Weapon weapon) 
        {
            DropWeapon();
            _currentWeapon = weapon;
            _currentWeapon.OwnerXpContainer = _owenerXPContainter;
            weapon.PickUp(gameObject);
        }
    }
}
