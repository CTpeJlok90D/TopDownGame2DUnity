using UnityEngine;

namespace AI.Tasks
{
    public abstract class Task : MonoBehaviour
    {
        [Header("Task")]
        [SerializeField] private int _priority;
        public int Priority 
        { 
            get => _priority; 
            set => _priority = value; 
        }

        public abstract void Execute();        

        public void AddPriority(int value)
        {
            _priority += value;
        }
    }
}