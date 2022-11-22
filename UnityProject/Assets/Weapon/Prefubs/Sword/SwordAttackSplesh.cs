using Effects;
using System;
using UnityEngine;

namespace Weapons
{
    public class SwordAttackSplesh : Shot
    {
        [SerializeField] private int _damage = 50;
        [SerializeField] private float _pulseForse = 1f;

        private XPcontainer _ownerXPContainer;

        public override Type CurrentShotType => typeof(SwordAttackSplesh);

        public override Shot Init(OwnerInfo _info)
        {
            _ownerXPContainer = _info.xpContainer;
            return this;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out EffectList effectList))
            {
                effectList.Add(new BaseDamage(_damage));
            }
            if (collision.TryGetComponent(out Rigidbody2D rigidbody2D))
            {
                rigidbody2D.AddForce(transform.up * _pulseForse);
            }
            if (collision.TryGetComponent(out XPgain xpGain))
            {
                xpGain.SetLastHittedPlayer(_ownerXPContainer);
            }
        }
    }
}
