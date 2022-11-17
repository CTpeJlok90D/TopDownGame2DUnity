using UnityEngine;
using UnityEngine.Events;
using Weapons;

namespace Player
{
    public class PickableItem : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onDrop = new UnityEvent();
        [SerializeField] private UnityEvent _onPickUp = new UnityEvent();

        private bool _onFloor = true;
        private OwnerInfo _ownerInfo;


        public bool OnFloor => _onFloor;
        public UnityEvent OnDrop => _onDrop;
        public UnityEvent OnPickUp => _onPickUp;
        public OwnerInfo OwnerInfo => _ownerInfo;

        public void Drop()
        {
            _onFloor = true;
            transform.SetParent(null);
            _onDrop.Invoke();
        }

        public void PickUp(OwnerInfo ownerInfo)
        {
            _ownerInfo = ownerInfo;
            transform.SetParent(OwnerInfo.transform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            _onFloor = false;
            _onPickUp.Invoke();
        }
    }
}
