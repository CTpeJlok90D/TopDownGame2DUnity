using UnityEngine;

namespace Weapons
{
    public class DoubleBarrielShotgunShot : Shot
    {
        [SerializeField] private SimpleBullet[] _simpleBullets;
        [SerializeField] private GameObject _light;

        private XPcontainer _xpContainer;

        public override Shot Init(OwnerInfo _info, float _currentBloomEffect)
        {
            _light.SetActive(true);
            _xpContainer = _info.xpContainer;
            foreach (SimpleBullet simpleBullet in _simpleBullets)
            {
                simpleBullet.Init(_xpContainer, _currentBloomEffect);
            }
            return this;
        }
    }
}