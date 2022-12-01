using UnityEngine;
using UnityEngine.Events;

namespace AI.Tasks
{
    public class Wait : Task
    {
        [SerializeField] private UnityEvent _waitEvent;
        public override void Execute()
        {
            _waitEvent.Invoke();
        }
    }
}