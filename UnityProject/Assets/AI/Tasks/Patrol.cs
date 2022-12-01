using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Tasks
{
    [Serializable]
    public class Patrol : Task
    {
        [Header("Patrol")]
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private List<Transform> _patrolPoints;

        private int _currentPointIndex = 0;
        public Transform CurrentPoint
        {
            get
            {
                if (_currentPointIndex >= _patrolPoints.Count)
                {
                    _currentPointIndex = 0;
                }
                return _patrolPoints[_currentPointIndex];
            }
        }

        public void Start()
        {
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        public override void Execute()
        {
            _agent.destination = _patrolPoints[0].position;
        }
    }
}