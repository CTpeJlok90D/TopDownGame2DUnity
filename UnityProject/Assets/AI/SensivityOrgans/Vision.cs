using AI.Memory;
using UnityEngine;

namespace AI
{
    public class Vision : MonoBehaviour
    {
        [SerializeField] private Brain _brain;
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out OnAISeeReflexFactor factor) && Physics2D.Raycast(transform.position, collision.transform.position - transform.position, Mathf.Infinity, 1 << 8))
            {
                _brain.AddFactor(factor.Factor, collision.transform);
            }
        }
    }
}