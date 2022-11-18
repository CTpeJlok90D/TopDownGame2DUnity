using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody; 
    [Header("Int-Sprite dictionary")]
    [SerializeField] private List<int> _keys = new();
    [SerializeField] private List<Material> _value = new();

    private void Awake()
    {
        if (_keys.Count != _value.Count)
        {
            Debug.LogError("Error intput value. Cant convert to dictionary");
        }
    }

    public void OnDeath()
    {
        _rigidbody.isKinematic =true;
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0;
    }

    public void OnCurrentHealthChanged(int current)
    {
        for (int i = 0; i < _keys.Count; i++)
        {
            if (current <= _keys[i])
            {
                _spriteRenderer.material = _value[i];
                return;
            }
        }
    }
}
