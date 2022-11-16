using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CopyTransform))]
    public class Legs : MonoBehaviour
    {
        [SerializeField] private TopDownCharacter2D _ownerCharacter;
        [SerializeField] private float _smoothStrench = 0.5f;

        private void Update()
        {
            transform.up = Vector3.MoveTowards(transform.up, _ownerCharacter.MoveDirection, _smoothStrench);
        }
    }
}
