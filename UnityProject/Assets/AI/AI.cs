using System.Collections.Generic;
using UnityEngine;
using AI.Tasks;

namespace AI
{
    public class AI : MonoBehaviour
    {
        [SerializeField] private List<Task> _tasks;

        private Task GetPreferentTask()
        {
            Task preferentTask = _tasks[0];
            foreach (Task task in _tasks)
            {
                if (task.Priority > preferentTask.Priority)
                {
                    preferentTask = task;
                }
            }
            return preferentTask;
        }

        private void Update()
        {
            GetPreferentTask().Execute();
        }

        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }
    }
}
