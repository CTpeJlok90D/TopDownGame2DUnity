using UnityEngine;

namespace Weapons
{
    public class RifleShot : Shot
    {
        [SerializeField] private SimpleBullet _bullet;
        [SerializeField] private GameObject _light;
        [SerializeField] private WeaponType _weaponType;

        public override WeaponType WeaponType => _weaponType;

        public override Shot Init(OwnerInfo ownerInfo,float _bloomInDegrees)
        {
            _light.transform.localPosition = Vector3.zero;
            _light.transform.localRotation = Quaternion.identity;
            _light.SetActive(true);
            _bullet.Init(ownerInfo.XPContainer, _bloomInDegrees);
            return this;
        }
    }
}
