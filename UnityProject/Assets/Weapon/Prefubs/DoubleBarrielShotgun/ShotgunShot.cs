using UnityEngine;

namespace Weapons
{
    public class ShotgunShot : Shot
    {
        [SerializeField] private SimpleBullet[] _simpleBullets;
        [SerializeField] private GameObject _light;
        [SerializeField] private WeaponType _weaponType;

        private XPcontainer _xpContainer;

        public override WeaponType WeaponType => _weaponType;

        public override Shot Init(OwnerInfo _info, float _currentBloomEffect)
        {
            _light.SetActive(true);
            _xpContainer = _info.XPContainer;
            foreach (SimpleBullet simpleBullet in _simpleBullets)
            {
                simpleBullet.Init(_xpContainer, _currentBloomEffect);
            }
            return this;
        }
    }
}