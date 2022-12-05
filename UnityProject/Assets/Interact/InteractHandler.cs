using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;
using Dialog;
using System.Collections.Generic;
using UnityEditor;

namespace Player 
{
    public class InteractHandler : MonoBehaviour
    {
        [SerializeField] private WeaponHoldier _weaponHolder;
        [SerializeField] private Dialoger _dialogView;
        [SerializeField] private Player _player;

        private List<IInteracteble> _interactebleItemsInZone = new();

        private void OnEnable()
        {
            InputHandler.Singletone.WorldMovement.Interact.started += Interact;
        }

        private void OnDisable()
        {
            InputHandler.Singletone.WorldMovement.Interact.started -= Interact;
        }

        public void Interact(InputAction.CallbackContext context)
        {
            if (_interactebleItemsInZone.Count == 0)
            {
                return;
            }
            IInteracteble closesestItem = _interactebleItemsInZone[0];
            float currentMinDistance = Vector2.Distance(closesestItem.transform.position, transform.position);
            foreach (IInteracteble item in _interactebleItemsInZone)
            {
                float currentDistance = Vector2.Distance(closesestItem.transform.position, transform.position);
                if (currentDistance < currentMinDistance)
                {
                    closesestItem = item;
                    currentMinDistance = currentDistance;
                }
            }
            closesestItem?.Interact(new InteractInfo()
            {
                WeaponHoldier = _weaponHolder,
                DialogView = _dialogView
            });
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteracteble item))
            {
                _interactebleItemsInZone.Add(item);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteracteble item)) 
            {
                _interactebleItemsInZone.Remove(item);
            }
        }
    }
}