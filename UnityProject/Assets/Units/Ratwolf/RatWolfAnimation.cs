using UnityEngine;
using UnityEngine.AI;

namespace Units.Ratwolf
{
    public class RatWolfAnimation : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;

        private void Update()
        {
            _animator.SetBool("Walking", _agent.velocity != Vector3.zero);
        }
    }
}