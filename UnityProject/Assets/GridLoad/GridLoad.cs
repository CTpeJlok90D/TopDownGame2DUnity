using System.Collections;
using UnityEngine;

public class GridLoad : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    [SerializeField] private AnimationCurve _speedCurve;
    private void Awake()
    {
        StartCoroutine(LoadGridCorrutine());
    }

    private IEnumerator LoadGridCorrutine()
    {
        float currentCurvePoint = 0;
        while (currentCurvePoint < _speedCurve.keys[^1].time)
        {
            float currentValue = _speedCurve.Evaluate(currentCurvePoint);
            _grid.cellGap = new Vector3(currentValue, currentValue);
            currentCurvePoint += Time.deltaTime;
            yield return null;
        }
        _grid.cellGap = Vector3.zero;
    }
}
