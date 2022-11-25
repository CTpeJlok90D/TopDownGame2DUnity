using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightBlink : MonoBehaviour
{
    [SerializeField] private bool _useCustomIntesiity;
    [SerializeField] private AnimationCurve _intesivityCurve;
    [SerializeField] private bool _useCustomOutterRadius;
    [SerializeField] private AnimationCurve _outterRadiusCurve;
    [SerializeField] private bool _useCustomInnerRadius;
    [SerializeField] private AnimationCurve _innerRadiusCurve;
    [SerializeField] private Light2D _light;

    [SerializeField] private float _currentIntesivityValue;
    [SerializeField] private float _currentOutterRadiusValue;
    [SerializeField] private float _currentInnerRadiusValue;

    void Update()
    {
        if (_useCustomIntesiity)
        {
            _light.intensity = _intesivityCurve.Evaluate(_currentIntesivityValue);
            _currentIntesivityValue += Time.deltaTime;
            if (_currentIntesivityValue > _intesivityCurve.keys[^1].time)
            {
                _currentIntesivityValue = 0;
            }
        }
        if (_useCustomOutterRadius)
        {
            _light.pointLightOuterRadius = _outterRadiusCurve.Evaluate(_currentOutterRadiusValue);
            _currentOutterRadiusValue += Time.deltaTime;
            if (_currentOutterRadiusValue > _outterRadiusCurve.keys[^1].time)
            {
                _currentOutterRadiusValue = 0;
            }
        }
        if (_useCustomInnerRadius)
        {
            _light.pointLightInnerRadius = _innerRadiusCurve.Evaluate(_currentInnerRadiusValue);
            _currentInnerRadiusValue += Time.deltaTime;
            if (_currentInnerRadiusValue > _innerRadiusCurve.keys[^1].time)
            {
                _currentInnerRadiusValue = 0;
            }
        }
    }

    private void OnValidate()
    {
        if (_intesivityCurve.keys.Length == 0 && _useCustomIntesiity)
        {
            _useCustomIntesiity = false;
            Debug.LogWarning("Intesivity curve is empty");
        }
        if (_outterRadiusCurve.keys.Length == 0 && _useCustomOutterRadius)
        {
            _useCustomOutterRadius = false;
            Debug.LogWarning("Outter Radius curve is empty");
        }
        if (_innerRadiusCurve.keys.Length == 0 && _useCustomInnerRadius)
        {
            _useCustomInnerRadius = false;
            Debug.LogWarning("Inner Radius curve is empty");
        }
    }
}
