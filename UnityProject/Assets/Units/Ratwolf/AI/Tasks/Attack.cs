using UnityEngine;
using Abilitys;
using UnityEngine.InputSystem;
using UnityEngine.AI;

namespace AI.Tasks
{
    public class Attack : Task, IHaveTarget
    {
        [SerializeField] private Follow _followTask;
        [SerializeField] private Transform _target;
        [SerializeField] private Ability _attackAbility;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _attackDistance = 2;

        public Transform Target 
        { 
            get => _target; 
            set => _target = value; 
        }

        private float DistanceToTarget => Vector3.Distance(_target.position, _agent.transform.position);

        public override void Execute()
        {
            _agent.stoppingDistance = _attackDistance;
            if (DistanceToTarget < _attackDistance)
            {
                _attackAbility.Use(InputActionPhase.Started);
            }
            _agent.destination = _target.position;
        }
    }
}