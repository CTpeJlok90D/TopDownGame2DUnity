using UnityEngine;
using UnityEngine.AI;

namespace AI.Tasks
{
    public class Follow : Task
    {
        [SerializeField] private Transform _target;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _stoppingDistance;

        public override void Execute()
        {
            _agent.destination = _target.position;
            _agent.stoppingDistance = _stoppingDistance;
        }
    }

}