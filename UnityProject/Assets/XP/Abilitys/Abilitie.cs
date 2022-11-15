using System.Collections;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Abilitys
{
    public abstract class Ability : MonoBehaviour
    {
        [SerializeField] private float _coolDown = 3f;
        [SerializeField] private float _prepairTime = 0f;
        [SerializeField] private UnityEvent _prepearStarted = new UnityEvent();
        [SerializeField] private UnityEvent _prepearCanceled = new UnityEvent();
        [SerializeField] private int _skillPointCost = 1;
        [SerializeField] private int _minLevelToUnlock = 0;
        private float _currentCooldown = 0f;
        private float _currentPrepairingTime = 0f;
        private Coroutine _prepair;
        private InputAction.CallbackContext _context;

        public bool Prepearing => _currentPrepairingTime > 0;
        public int SkillPointCost => _skillPointCost;
        public int MinLevelToUnlock => _minLevelToUnlock;
        protected float PrepairTime => _prepairTime;
        protected bool CanUse => _currentCooldown == 0f && _currentPrepairingTime == 0;
        protected float CurrentCooldown => _currentCooldown;
        protected UnityEvent PrepearStarted => _prepearStarted;
        protected UnityEvent PrepaerCanceled => _prepearCanceled;
        protected InputAction.CallbackContext InputContext => _context;
        protected virtual bool ReduceCooldownCondiction => true;
        protected virtual bool UseCondiction => true;


        public void Use(InputAction.CallbackContext context)
        {
            _context = context;
            if (CanUse == false && UseCondiction)
            {
                return;   
            }
            _currentPrepairingTime = _prepairTime;
            _prepair = StartCoroutine(PrepairTimeCorutine());
        }
        
        private IEnumerator PrepairTimeCorutine()
        {
            _prepearStarted.Invoke();
            _currentPrepairingTime = _prepairTime;
            while (_currentPrepairingTime > 0)
            {
                _currentPrepairingTime = Mathf.Clamp(_currentPrepairingTime - Time.deltaTime, 0, Mathf.Infinity);
                yield return null;
            }
            if (CanUse)
            {
                Execute();
                _currentCooldown = _coolDown;
            }
        }

        protected abstract void Execute();

        public void StopPrepearing()
        {
            if (_prepairTime == 0)
            {
                return;
            }
            PrepaerCanceled.Invoke();
            StopCoroutine(_prepair);
            _currentPrepairingTime = 0;
        }

        private void ReduceCoolDown()
        {
            _currentCooldown = Mathf.Clamp(_currentCooldown-Time.deltaTime, 0, Mathf.Infinity);
        } 

        private void FixedUpdate()
        {
            if (ReduceCooldownCondiction)
            {
                ReduceCoolDown();
            }
        }
    }
}