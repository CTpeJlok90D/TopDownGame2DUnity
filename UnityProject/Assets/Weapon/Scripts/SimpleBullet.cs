using UnityEngine;
using Effects;
using VectorExtensions;

namespace Weapons 
{
    public class SimpleBullet : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _speed = 10;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private XPcontainer _container;
        private Vector3 _position;
        private Quaternion _rotation;

        private void Awake()
        {
            _position = transform.localPosition;
            _rotation = transform.localRotation;
        }

        public SimpleBullet Init(XPcontainer sender, float bloomIndegrees)
        {
            transform.localPosition = _position;
            transform.localRotation = Quaternion.Euler(_rotation.eulerAngles + new Vector3(0,0,Random.Range(-bloomIndegrees, bloomIndegrees)));
            gameObject.SetActive(true);
            _container = sender;
            return this;
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.TryGetComponent(out EffectList effectList))
            {
                effectList.Add(new BaseDamage(_damage));
            }
            if (collision2D.gameObject.TryGetComponent(out XPgain xpGain))
            {
                xpGain.SetLastHittedPlayer(_container);
            }
            gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = transform.up * _speed;
        }
    }
}