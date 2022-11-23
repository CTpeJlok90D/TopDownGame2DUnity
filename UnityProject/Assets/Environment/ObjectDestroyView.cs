using Range;
using UnityEngine;

public class ObjectDestroyView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;
    [Header("Int-Sprite dictionary")]
    [SerializeField] private RangeSpriteDictionarityItem<Sprite>[] _rangeSpriteDictionaryItems;

    private RangeSpriteDictionarity _rangeSprite;

    private void Awake()
    {
        _rangeSprite = new(_rangeSpriteDictionaryItems);
    }

    public void OnDeath()
    {
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0;
        _spriteRenderer.sprite = _rangeSprite[0];
    }

    public void OnCurrentChanged(int current, int max)
    {
        _spriteRenderer.sprite = _rangeSprite[current];
    }
}