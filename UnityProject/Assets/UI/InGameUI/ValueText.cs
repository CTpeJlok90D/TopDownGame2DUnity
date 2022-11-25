using UnityEngine;
using TMPro;

public class ValueText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _textBeforeValue = "";
    [SerializeField] private string _textAfterValue = "";

    protected TMP_Text Text => _text;

    public void OnCorrentChanged(int current)
    {
        SetValue(current);
    }

    public void SetValue(int newValue)
    {
        _text.text = _textBeforeValue + newValue + _textAfterValue;
    }
}
