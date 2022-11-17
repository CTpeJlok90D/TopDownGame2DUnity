using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Player;

namespace Weapons 
{
    public abstract class Weapon : PickableItem, IInteracteble
    {
        [Header("Weapon")]
        [SerializeField] private UnityEvent _onAttack = new UnityEvent();
        [SerializeField] private float _timeBetweenAttacks = 0.1f;

        private float _cantAttackNextSeconds = 0;
        private UnityEvent<InputActionPhase> _weaponIsed = new();
        private UnityEvent _update = new();

        public bool CanAttack => _cantAttackNextSeconds == 0 && AttackCodiction;
        protected UnityEvent UpdateEvent => _update;
        protected UnityEvent<InputActionPhase> WeaponUsed => _weaponIsed;

        public abstract Type ShotType {get;}
        protected virtual bool AttackCodiction => true;
        protected abstract void ForsetAttack();

        public void Use(InputActionPhase phase)
        {
            _weaponIsed.Invoke(phase);
        }

        public void Interact(InteractInfo info)
        {
            info.WeaponHoldier.PutWeapon(this);
        }

        protected void Attack()
        {
            if (CanAttack == false)
            {
                return;
            }

            _cantAttackNextSeconds += _timeBetweenAttacks;
            ForsetAttack();
            _onAttack.Invoke();
        }

        protected void AddCantShootTime(float time)
        {
            _cantAttackNextSeconds += time;
        }

        protected void ReduceCoolDown(float value)
        {
            _cantAttackNextSeconds = Mathf.Clamp(_cantAttackNextSeconds - value, 0, Mathf.Infinity);
        }

        protected void Update()
        {
            ReduceCoolDown(Time.deltaTime);
            UpdateEvent.Invoke();
        }
    }
}