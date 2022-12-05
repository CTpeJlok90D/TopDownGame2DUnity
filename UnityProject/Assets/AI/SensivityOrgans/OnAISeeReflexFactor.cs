using UnityEngine;
using AI.Memory;

namespace AI
{
    public class OnAISeeReflexFactor : MonoBehaviour
    {
        [SerializeField] private Factor factor;

        public Factor Factor => factor;
    }
}