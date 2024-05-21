using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : UIElement
{
    public TextMeshProUGUI ui;

    private void Start()
    {
        ui = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateElement()
    {
        ui.text = "$" + GameManager.Instance.score;
    }
}
