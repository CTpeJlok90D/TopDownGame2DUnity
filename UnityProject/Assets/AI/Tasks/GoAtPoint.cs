using UnityEngine;
using UnityEngine.AI;

namespace AI.Tasks
{
    public class GoAtPoint : Task, IHaveTarget
    {
        [SerializeField] private Vector3 position;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _stoppingDistance = 1;

        public Transform Target 
        {
            set => position = value.position; 
        }

        public override void Execute()
        {
            _agent.stoppingDistance = _stoppingDistance;
            _agent.destination = position;
        }
    }
}