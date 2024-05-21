using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalButton : MonoBehaviour
{
    [SerializeField]
    int id;
    [SerializeField]
    JournalManager JournalManager;

    private Image image;
    
    private void Start()
    {
        image = GetComponent<Image>();

        if (image == null)
            Debug.Log("No image found!");

        image.sprite = GameManager.Instance.fishSelection[id].sprite;
    }

    public void ChangePage()
    {
        JournalManager.ChangePage(id);
    }
}
