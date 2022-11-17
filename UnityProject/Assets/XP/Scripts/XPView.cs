using System.Collections.Generic;
using UnityEngine;

public class XPView : MonoBehaviour
{
    [SerializeField] private XPGainView _xpGainView;

    public void OnXpChange(int addedValue)
    {
        _xpGainView.OnXPGain(addedValue);
    }
}