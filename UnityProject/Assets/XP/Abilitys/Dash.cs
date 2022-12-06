using UnityEngine;
using UnityEngine.InputSystem;

namespace Abilitys
{
    public class Dash : Ability
    {
        [SerializeField] private float _dashStrench;
        [SerializeField] private Rigidbody2D _owner;
        [SerializeField] private Transform _head;

        protected override void Execute()
        {
            _owner.AddForce(_head.up * _dashStrench);
        }

        private void OnEnable()
        {
            InputHandler.Singletone.WorldMovement.Dash.started += Use;
        }

        private void OnDisable()
        {
            InputHandler.Singletone.WorldMovement.Dash.started -= Use;
        }

        private void Use(InputAction.CallbackContext context)
        {
            Use(context.phase);
        }
    }
}