using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public abstract class Shot : MonoBehaviour 
    {
        private static Dictionary<Type,List<Shot>> _instanses = new();

        public abstract Shot Init(OwnerInfo _info, float _currentBloomEffect);
        public Type CurrentShotType => GetType();

        public static Shot Summon(Shot shotPrefub, Type shotType, Transform spawnpointTransform)
        {
            Shot shotInstance;
            if (_instanses.ContainsKey(shotType) == false)
            {
                _instanses.Add(shotType, new List<Shot>());
            }
            if (_instanses[shotType].Count == 0)
            {
                shotInstance = Instantiate(shotPrefub);
            }
            else
            {
                shotInstance = _instanses[shotType][0];
            }
            shotInstance.transform.position = spawnpointTransform.position;
            shotInstance.transform.rotation = spawnpointTransform.rotation;
            shotInstance.gameObject.SetActive(true);
            return shotInstance;
        }

        public static void ClearInstances(Type instanceType)
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
            _instanses[CurrentShotType].Remove(this);
        }

        private void OnDisable()
        {
            if (_instanses.ContainsKey(CurrentShotType))
            {
                _instanses[CurrentShotType].Add(this);
                return;
            }
            Destroy(gameObject);
        }
    }
}