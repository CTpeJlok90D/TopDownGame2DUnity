using UnityEngine;

namespace Units.Ratwolf
{
    public class RatWolfAnimation : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Animator _animator;

        private void Update()
        {
            _animator.SetBool("Walking", _rigidbody2D.velocity != Vector2.zero);
        }
    }
}