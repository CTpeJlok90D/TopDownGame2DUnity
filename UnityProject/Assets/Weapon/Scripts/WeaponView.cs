using UnityEngine;

namespace Weapons
{
    public class WeaponView : MonoBehaviour
    {
        [Header("Image")]
        [SerializeField] private Sprite _onFloorSprite;
        [SerializeField] private Sprite _inHandsSprite;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void OnDrop()
        {
            _spriteRenderer.sprite = _onFloorSprite;
        }

        public void OnPickUp()
        {
            _spriteRenderer.sprite = _inHandsSprite;
        }

    }
}
