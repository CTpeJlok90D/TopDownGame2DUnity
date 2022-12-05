using UnityEngine;
using UnityEngine.AI;
using Health;

namespace Units.Ratwolf
{
    public class RatWolfAnimation : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;
        [SerializeField] private UnitHealth _health;
        [SerializeField] private float _animationSpeedCoefficient = 1.3f;

        private float _currentSpeed => _agent.velocity.magnitude;

        private void Update()
        {
            _animator.SetFloat("Speed", _currentSpeed);
            _animator.SetBool("IsDead", _health.Current == 0);
            _animator.speed = _currentSpeed / _agent.speed * _animationSpeedCoefficient;
        }
    }
}