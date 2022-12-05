using UnityEngine;
using UnityEngine.AI;

namespace AI.Tasks
{
    public class KeepDistance : Task, IHaveTarget
    {
        [Header("Keep distance")]
        [SerializeField] private float _minDistanceToTarget;
        [SerializeField] private float _maxDistanceToTarget;
        [SerializeField] private Transform _target;
        [SerializeField] private NavMeshAgent _agent;

        public Transform Target 
        { 
            get => _target; 
            set => _target = value; 
        }

        public override void Execute()
        {
            float distanceToTarget = Vector3.Distance(_agent.transform.position, _target.position);
            _agent.stoppingDistance = _minDistanceToTarget;

            if (distanceToTarget < _minDistanceToTarget)
            {
                _agent.isStopped = false;
                _agent.destination = -_target.position;
                return;
            }
            if (distanceToTarget > _maxDistanceToTarget)
            {
                _agent.isStopped = false;
                _agent.destination = _target.position;
                return;
            }
            _agent.isStopped = true;
        }
    }
}
