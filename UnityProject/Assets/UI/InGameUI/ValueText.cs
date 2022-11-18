using UnityEngine;
using TMPro;

public class ValueText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _textBeforeValue = "";
    [SerializeField] private string _textAfterValue = "";

    public void OnCorrentChanged(int current)
    {
        _text.text = _textBeforeValue + current + _textAfterValue;
    }
}
