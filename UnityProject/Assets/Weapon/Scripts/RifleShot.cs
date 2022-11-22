using System;
using UnityEngine;

namespace Weapons
{
    public class RifleShot : Shot
    {
        [SerializeField] private SimpleBullet _bullet;
        [SerializeField] private GameObject _light;

        public override Type CurrentShotType => typeof(RifleShot);

        public override Shot Init(OwnerInfo ownerInfo)
        {
            _light.transform.localPosition = Vector3.zero;
            _light.transform.localRotation = Quaternion.identity;
            _light.SetActive(true);
            _bullet.Init(ownerInfo.xpContainer);
            return this;
        }
    }
}
