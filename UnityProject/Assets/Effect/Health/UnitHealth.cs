using UnityEngine;
using UnityEngine.Events;

namespace Health
{
    public class UnitHealth : MonoBehaviour
    {
        [SerializeField] private int _max = 100;
        [SerializeField] private int _current = 100;
        [SerializeField] private UnityEvent _death = new UnityEvent();
        [SerializeField] private UnityEvent<int> _takeDamage = new();
        [SerializeField] private UnityEvent<int> _gotHeal = new();
        [SerializeField] private UnityEvent<int,int> _currentChanged = new();

        private bool _isDead = false;

        public int Max => _max;
        public int Min => _current;

        public int Current
        {
            get => _current;
            set
            {
                if (value - _current >= 0)
                {
                    _gotHeal.Invoke(value - _current);
                }
                else
                {
                    _takeDamage.Invoke(value - _current);
                }
                _current = Mathf.Clamp(value, 0, _max);
                _currentChanged.Invoke(_current, _max);
                if (_current <= 0 && _isDead == false)
                {
                    _isDead = true;
                    _death.Invoke();
                }
            }
        }

        public void TakeEffectImpact(Impact impact)
        {
            if (impact.Heal != 0 || impact.Damage != 0)
            {
                Current += impact.Heal - impact.Damage;
            }
        }
    }
}