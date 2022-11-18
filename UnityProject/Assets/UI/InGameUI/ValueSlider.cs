using UnityEngine;
using UnityEngine.UI;

public class ValueSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void OnCurrentChanged(int newValue, int maxValue)
    {
        _slider.value = (float)newValue / maxValue;
    }
}