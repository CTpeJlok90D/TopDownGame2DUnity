using Effects;
using UnityEngine;

namespace Weapons
{
    public class SpleshAttack : Shot
    {
        [SerializeField] private int _damage = 50;
        [SerializeField] private float _pulseForse = 1f;
        [SerializeField] private WeaponType _weaponType;

        private OwnerInfo _ownerInfo;

        public override WeaponType WeaponType => _weaponType;

        public override Shot Init(OwnerInfo info, float _bloomInDegrees)
        {
            _ownerInfo = info;
            return this;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out EffectList effectList))
            {
                if (effectList == _ownerInfo.EffectList)
                {
                    return;
                }
                effectList.Add(new BaseDamage(_damage));
            }
            if (collision.TryGetComponent(out Rigidbody2D rigidbody2D))
            {
                rigidbody2D.AddForce(transform.up * _pulseForse);
            }
            if (collision.TryGetComponent(out XPgain xpGain))
            {
                xpGain.SetLastHittedPlayer(_ownerInfo.XPContainer);
            }
        }
    }
}
