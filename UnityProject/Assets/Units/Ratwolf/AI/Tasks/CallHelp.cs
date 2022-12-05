using UnityEngine;
using UnityEngine.Events;

namespace AI.Tasks
{
    public class CallHelp : Task
    {
        [SerializeField] private UnityEvent _helpCalled;
        [SerializeField] private float _timeToCall;

        private float _currentTimeToCall;

        private void Start()
        {
            _currentTimeToCall = _timeToCall;
            _helpCalled.AddListener(() =>
            {
                _currentTimeToCall = _timeToCall;
            }
            );
        }


        public override void Execute()
        {
            if (_currentTimeToCall > 0)
            {
                _currentTimeToCall = Mathf.Clamp(_currentTimeToCall - Time.deltaTime, 0, Mathf.Infinity);
                return;
            }
            _helpCalled.Invoke();
        }
    }
}
