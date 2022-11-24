using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public abstract class Shot : MonoBehaviour 
    {
        private static Dictionary<WeaponType,List<Shot>> _instanses = new();

        public abstract Shot Init(OwnerInfo _info, float _currentBloomEffect);
        public abstract WeaponType WeaponType { get; }

        public static Shot Summon(Shot shotPrefub, Transform spawnpointTransform)
        {
            Shot shotInstance;
            if (_instanses.ContainsKey(shotPrefub.WeaponType) == false)
            {
                _instanses.Add(shotPrefub.WeaponType, new List<Shot>());
            }
            if (_instanses[shotPrefub.WeaponType].Count == 0)
            {
                shotInstance = Instantiate(shotPrefub);
            }
            else
            {
                shotInstance = _instanses[shotPrefub.WeaponType][0];
            }
            shotInstance.transform.position = spawnpointTransform.position;
            shotInstance.transform.rotation = spawnpointTransform.rotation;
            shotInstance.gameObject.SetActive(true);
            return shotInstance;
        }

        public static void ClearInstances(WeaponType instanceType)
        {
            if (_instanses.ContainsKey(instanceType) == false)
            {
                return;
            }
            foreach (Shot instance in _instanses[instanceType])
            {
                Destroy(instance.gameObject);
            }
            _instanses.Clear();
        }

        private void OnEnable()
        {
            _instanses[WeaponType].Remove(this);
        }

        private void OnDisable()
        {
            if (_instanses.ContainsKey(WeaponType))
            {
                _instanses[WeaponType].Add(this);
                return;
            }
            Destroy(gameObject);
        }
    }
}