using UnityEngine;
using UnityEngine.AI;

namespace AI.Tasks
{
    public class Follow : Task, IHaveTarget
    {
        [SerializeField] private Transform _target;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _stoppingDistance;

        public Transform Target 
        { 
            get => _target; set => _target = value; 
        }

        public override void Execute()
        {
            _agent.destination = _target.position;
            _agent.stoppingDistance = _stoppingDistance;
        }

        public void SetTarget(Transform newTarget)
        {
            _target = newTarget;
        }
    }

}