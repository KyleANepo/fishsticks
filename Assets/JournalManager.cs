using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour
{
    public GameObject JournalMenu;
    private bool Active = false;

    // for the name, picture, and description of the fish
    public TextMeshProUGUI fish;
    public Image picture; // make sure to use picture.sprite :P
    public TextMeshProUGUI description;

    // Update is called once per frame
    void Update()
    {
        SetJournal();
    }

    void SetJournal()
    {
        if (!GameManager.Instance.Paused)
        {
            if (Input.GetKeyDown(KeyCode.J) && !Active)
            {
                DisplayJournal();
            }
            else if (Input.GetKeyDown(KeyCode.J) && Active)
            {
                DisableJournal();
            }
        }
    }

    public void ButtonSetJournal()
    {
        if (!GameManager.Instance.Paused)
        {
            if (!Active)
            {
                DisplayJournal();
            }
            else if (Active)
            {
                DisableJournal();
            }
        }
    }

    void DisplayJournal()
    {
        JournalMenu.SetActive(true);
        Active = true;
    }
     
    void DisableJournal()
    {
        JournalMenu.SetActive(false);
        Active = false;
    }

    // get index (id) of fish, grab it from gamemanager
    public void ChangePage(int index)
    {
        fish.text = GameManager.Instance.fishSelection[index].type;
        picture.sprite = GameManager.Instance.fishSelection[index].sprite;
        description.text = GameManager.Instance.fishSelection[index].description;
    }
}
