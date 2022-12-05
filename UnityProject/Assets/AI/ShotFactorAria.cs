using AI.Memory;
using UnityEngine;

public class ShotFactorAria : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Brain brain))
        {
            brain.AddFactor(Factor.Shot, gameObject.transform);
        }
    }
}
