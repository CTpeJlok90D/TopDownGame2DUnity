using System.Collections;
using TMPro;
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
    private Coroutine _hideCorrutine;
    private float _cofficient = 0;
    public void OnXPGain(int gainValue)
    {
        _currentValue += gainValue;
        Show();
        if (_hideCorrutine != null)
        {
            StopCoroutine(_hideCorrutine);
        }
        _hideCorrutine = StartCoroutine(HideCorrutine());
    }

    private void Show()
    {
        _text.color = _normalColor;
        _currentVisibleTime = _visibleTime;
        _text.text = $"+{_currentValue} xp";
        transform.position = _xpViewPosition.position;
        _cofficient = 0;
        gameObject.SetActive(true);
    }

    private IEnumerator HideCorrutine()
    {
        while (_currentVisibleTime > 0)
        {
            _currentVisibleTime -= Time.deltaTime;
            yield return null;
        }
        while (_cofficient <= 1)
        {
            _text.color = Color.Lerp(_normalColor, _hideColor, _cofficient);
            _cofficient += Time.deltaTime * _hideSpeed;
            yield return null;
        }
        gameObject.SetActive(false);
        _currentValue = 0;
        _hideCorrutine = null;
    }
}