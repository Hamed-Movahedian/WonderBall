using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PercentageText : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUgui;

    public void SetValue(float value)
    {
        if(_textMeshProUgui==null)
            _textMeshProUgui = GetComponent<TextMeshProUGUI>();

        _textMeshProUgui.text = "%" + Mathf.RoundToInt(value * 100);
    }
}
