using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScoreUI scoreUI;
    public ComboUI comboUI;

    // Start is called before the first frame update
    void Start()
    {
        scoreUI.UpdateElement();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int score)
    {
        GameManager.Instance.score += score;
        GameManager.Instance.combo++;
        scoreUI.UpdateElement();
        comboUI.UpdateElement();
    }

    public void ResetCombo()
    {
        GameManager.Instance.combo = 0;
        comboUI.Hide();
    }
}