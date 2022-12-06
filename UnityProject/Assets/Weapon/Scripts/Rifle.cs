using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Weapons 
{
    public sealed class Rifle : Weapon, IReloadeble
    {
        [Header("Rifle")]
        [SerializeField] private Transform _bulletSpawnpoint;
        [SerializeField] private Shot _bulletPrefub;
        [SerializeField] private bool _fullAutomatic = false;
        [SerializeField] private int _maxAmmoCount = 30;
        [SerializeField] private int _ammoCount = 30;
        [SerializeField] private float _reloadingTime = 0.5f;
        [SerializeField] private float _cameraImpactCoefficient;
        [SerializeField] private TimeLineEvent[] _reloadTimeLineEvents;
        [SerializeField] private AnimationCurve _bloomCurve = new();
        [SerializeField] private float _bloomFallRate = 1;
        [SerializeField] private float _bloomPerShot = 1;

        private InputActionPhase _phase;
        private TimeLine _reloadTimeLine;
        private Coroutine _reloadTimeLineCourutine;
        private UnityEvent<int> _ammoCountChanged = new();
        private float _currentBloomCoefficient;

        protected override bool AttackCodiction => AmmoCount > 0;
        private float MaxBloomValue => _bloomCurve.keys[^1].value;

        public int AmmoCount 
        {
            get
            {
                return _ammoCount;
            }
            private set
            {
                _ammoCount = value;
                _ammoCountChanged.Invoke(value);
            }
        }

        public UnityEvent<int> AmmoCountChanged => _ammoCountChanged;

        private void Awake()
        {
            OnDropEvent.AddListener(OnDrop);
            WeaponUsed.AddListener(UseIt);
            UpdateEvent.AddListener(OnUpdate);
            _reloadTimeLine = new(_reloadTimeLineEvents);
            _reloadTimeLineEvents[0].Event.AddListener(() => AddCantShootTime(_reloadingTime));
            _reloadTimeLineEvents[^1].Event.AddListener(() => AmmoCount = _maxAmmoCount);
        }

        private void UseIt(InputActionPhase phase)
        {
            _phase = phase;
            if (_phase == InputActionPhase.Started)
            {
                Attack();
            }
        }

        public void Reload()
        {
            AmmoCount = 0;
            _reloadTimeLineCourutine = StartCoroutine(_reloadTimeLine.StartTimerCorutine());
        }

        protected override void ForsetAttack()
        {
            AmmoCount -= 1;
            Shot.Summon(_bulletPrefub, _bulletSpawnpoint).Init(OwnerInfo, _bloomCurve.Evaluate(_currentBloomCoefficient));
            _currentBloomCoefficient += Mathf.Clamp(_currentBloomCoefficient + _bloomPerShot, 0, MaxBloomValue);
            Camera.main.transform.position += -transform.up * _cameraImpactCoefficient;
        }

        private void OnDrop()
        {
            if (_reloadTimeLineCourutine != null)
            {
                StopCoroutine(_reloadTimeLineCourutine);   
            }
        }

        private void OnUpdate()
        {
            if (_phase == InputActionPhase.Performed && _fullAutomatic)
            {
                Attack();
            }
            if (_phase == InputActionPhase.Canceled)
            {
                ReduceBloom(Time.deltaTime * _bloomFallRate);
            }
        }
        private void ReduceBloom(float value)
        {
            _currentBloomCoefficient = Mathf.Clamp(_currentBloomCoefficient - value, 0, MaxBloomValue);
        }

        private void OnValidate() 
        {
            if (_reloadTimeLineEvents.Length > 0)
            {
                _reloadTimeLineEvents[^1] = new TimeLineEvent(new UnityEvent(), _reloadingTime);
            }
            if (_reloadTimeLineEvents.Length >= 2)
            {
                return;
            }
            Debug.LogWarning("This weapon MUST have 2 reload evets or more");
            _reloadTimeLineEvents = new TimeLineEvent[]
            {
                new TimeLineEvent(new UnityEvent(), 0),
                new TimeLineEvent(new UnityEvent(), _reloadingTime)
            };
        }
    }
}
