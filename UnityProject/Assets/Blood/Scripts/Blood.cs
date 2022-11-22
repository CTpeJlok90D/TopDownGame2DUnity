using UnityEngine;

public class Blood : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _bloodSprites;

    private void OnEnable()
    {
        _spriteRenderer.sprite = _bloodSprites[Random.Range(0, _bloodSprites.Length)];
    }
}
