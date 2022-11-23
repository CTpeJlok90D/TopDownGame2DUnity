using UnityEngine;

namespace VectorExtensions
{
    public static class VectorExptentions
    {
        public static Vector2 Rotated(this Vector2 @this, float angle)
        {
            angle /= 100;
            return new Vector2(
                @this.x * Mathf.Cos(angle) + @this.y * Mathf.Sin(angle),
                @this.x * Mathf.Sin(angle) + @this.y * Mathf.Cos(angle)
                );
        }
    }
}
