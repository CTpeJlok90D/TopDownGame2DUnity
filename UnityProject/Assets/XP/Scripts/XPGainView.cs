using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public sealed class XPGainView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Transform _xpViewPosition;
    [Header("Colors")]
    [SerializeField] private Color _normalColor;
    [SerializeField] private Color _hideColor;
    [Header("Timers")]
    [SerializeField] private float _visibleTime = 1.5f;
    [SerializeField] private float _hideSpeed = 1;

    private float _currentVisibleTime;
    private int _currentValue = 0;

    private void OnEnable()
    {
        _currentVisibleTime = _visibleTime;
    }

    public void OnXPGain(int gainValue)
    {
        _text.color = _normalColor;
        _currentValue += gainValue;
        _currentVisibleTime = _visibleTime;
        _text.text = $"+{_currentValue} xp";
        transform.position = _xpViewPosition.position;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        VisibleUpdate();
    }

    private void VisibleUpdate()
    {
        _currentVisibleTime -= Time.deltaTime;
        if (_currentVisibleTime <= 0)
        {
            Hide();
        }
    }

    private void Hide()
    {
        StartCoroutine(HideCorrutine());
    }

    private IEnumerator HideCorrutine()
    {
        float cofficient = 0;
        while (cofficient <= 1)
        {
            _text.color = Color.Lerp(_normalColor, _hideColor, cofficient);
            cofficient += Time.deltaTime * _hideSpeed;
            yield return null;
        }
        gameObject.SetActive(false);
        _currentValue = 0;
    }
}