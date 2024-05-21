using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboUI : UIElement
{
    public TextMeshProUGUI ui;

    private void Start()
    {
        ui = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateElement()
    {
        ui.text = "COMBO X" + GameManager.Instance.combo;
    }

    public void Hide()
    {
        ui.text = "";
    }
}
