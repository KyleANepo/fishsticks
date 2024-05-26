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

        if (GameManager.Instance.fishSelection.Count > id)
            image.sprite = GameManager.Instance.fishSelection[id].sprite;

       image.color = Color.black;
    }

    private void FixedUpdate() // i know this is bad practice ok????
    {
        if (GameManager.Instance.fishCaught[id] == true)
           image.color = Color.white;
    }

    public void ChangePage()
    {
        if (GameManager.Instance.fishSelection.Count > id && GameManager.Instance.fishCaught[id] == true) 
            JournalManager.ChangePage(id);
    }
}
