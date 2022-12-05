using AI.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AI.Memory
{
    public class Brain : MonoBehaviour
    {
        [SerializeField] private List<Memory> _memorys = new();
        [SerializeField] private List<MemoryDictionarity> _reactions = new();
        [SerializeField] private List<Task> _targetebleTasksInspector = new();

        private List<IHaveTarget> _targetebleTasks = new();

        private Dictionary<Factor, List<Memory>> _reactionDictionarity = new();

        public void Awake()
        {
            foreach (MemoryDictionarity reaction in _reactions)
            {
                _reactionDictionarity.Add(reaction.Factor, reaction.Memorys);
            }
        }

        public void AddFactor(Factor factor, Transform targetTransform)
        {
            foreach (IHaveTarget task in _targetebleTasks)
            {
                task.Target = targetTransform;
            }
            foreach (Memory memory in _reactionDictionarity[factor]) 
            {
                bool added = false;
                foreach (Memory memoryIterator in _memorys)
                {
                    if (memoryIterator == memory)
                    {
                        memoryIterator.UpdateDituration(memory.Dituration);
                        added = true;
                    }
                }
                if (added == false)
                {
                    _memorys.Add(memory.Copy());
                    memory.ImpactOnPriority();
                }
            }
        }

        private void Update()
        {
            ReduceDetiration(Time.deltaTime);
        }

        private void ReduceDetiration(float time)
        {
            foreach (Memory memory in _memorys.ToArray())
            {
                memory.ReduceCooldown(time);
                if (memory.Dituration <= 0)
                {
                    memory.RemoveImpactOnPriority();
                    _memorys.Remove(memory);
                }
            }
        }

        private void OnValidate()
        {
            _targetebleTasks = new();

            for (int i = 0; i < _targetebleTasksInspector.Count; i++)
            {
                if (_targetebleTasksInspector[i] is null)
                {
                    continue;
                }
                if (_targetebleTasksInspector[i] is IHaveTarget)
                {
                    _targetebleTasks.Add((IHaveTarget)_targetebleTasksInspector[i]);
                    continue;
                }
                Debug.LogWarning("In this list must be IHaveTarget tasks only!");
                _targetebleTasksInspector.RemoveAt(i);
            }
        }
    }
}