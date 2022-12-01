using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace AI.Tasks
{
    [Serializable]
    public class Patrol : Task
    {
        [Header("Patrol")]
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _timeBetweenPoints = 3;
        [SerializeField] private float _stopDistance = 2f;
        [SerializeField] private List<Transform> _patrolPoints;
        [SerializeField] private UnityEvent _pointCame = new();

        private int _currentPointIndex = 0;
        private float _currentTimeBetweenPoints = 0;

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

        private void Start()
        {
            _pointCame.AddListener(OnCamePoint);
        }

        private void OnCamePoint()
        {
            _currentTimeBetweenPoints = _timeBetweenPoints;
        }

        public override void Execute()
        {
            _agent.stoppingDistance = _stopDistance;
            if (_currentTimeBetweenPoints > 0)
            {
                _currentTimeBetweenPoints = Mathf.Clamp(_currentTimeBetweenPoints - Time.deltaTime, 0, Mathf.Infinity);
                if (_currentTimeBetweenPoints == 0)
                {
                    _currentPointIndex++;
                    _agent.destination = CurrentPoint.position;
                }
                return;
            }
            if (_agent.velocity == Vector3.zero)
            {
                _currentTimeBetweenPoints = _timeBetweenPoints;
                _pointCame.Invoke();
            }
            _agent.destination = CurrentPoint.position;
        }
    }
}