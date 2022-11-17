using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons 
{
    public sealed class Rifle : Weapon, IReloadeble
    {
        [Header("Rifle")]
        [SerializeField] private Transform _bulletSpawnpoint;
        [SerializeField] private RifleShot _bulletPrefub;
        [SerializeField] private bool _fullAutomatic = false;
        [SerializeField] private int _maxAmmoCount = 30;
        [SerializeField] private float _reloadingTime = 0.5f;
        [SerializeField] private TimeLineEvent[] _onReloadTimeLine;
        [SerializeField] private int _ammoCount = 30;

        private InputActionPhase _phase;

        protected override bool AttackCodiction => _ammoCount > 0;

        public override Type ShotType => typeof(RifleShot);

        private void Awake()
        {
            WeaponUsed.AddListener(OnUse);
            UpdateEvent.AddListener(OnUpdate);
        }

        private void OnUse(InputActionPhase phase)
        {
            _phase = phase;
            if (_phase == InputActionPhase.Started)
            {
                Attack();
            }
        }

        public void Reload()
        {
            AddCantShootTime(_reloadingTime);
            _ammoCount = _maxAmmoCount;
        }

        protected override void ForsetAttack()
        {
            _ammoCount -= 1;
            Shot.Summon(_bulletPrefub, ShotType, _bulletSpawnpoint).Init(OwnerInfo);
        }

        private void OnUpdate()
        {
            if (_phase == InputActionPhase.Performed && _fullAutomatic)
            {
                Attack();
            }
        }
    }
}
