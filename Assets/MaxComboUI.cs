using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaxComboUI : UIElement
{
    public TextMeshProUGUI ui;

    private void Start()
    {
        ui = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateElement()
    {
        ui.text = "X" + GameManager.Instance.maxCombo;
    }
}
