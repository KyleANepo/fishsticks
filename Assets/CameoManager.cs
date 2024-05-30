using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameoManager : MonoBehaviour
{
    public List<Cameo> cameos = new List<Cameo>();
    public Cameo curCameo;
    public TextMeshProUGUI dialogue;

    private bool spoken = false;

    // Start is called before the first frame update
    void Start()
    {
        RandomCameo();
    }

    // call this in shop manager and on game start!
    public void RandomCameo()
    {
        if (Random.Range(1, 11) > 7)
        {
            SetCameo();
        }
    }

    public void SetCameo()
    {
        curCameo = Instantiate(cameos[Random.Range(0, cameos.Count)], this.transform.position, this.transform.rotation); //create pointer to current fish on screen
    }

    public void DeleteCameo()
    {
        if (curCameo != null)
        {
            Destroy(curCameo.gameObject);
            dialogue.text = "";
        }
    }

    public void SetCameoText()
    {
        if (curCameo != null && curCameo.strings != null)
        {
            if (!spoken)
            {
                dialogue.text = curCameo.strings[Random.Range(0, curCameo.strings.Count)];
                spoken = true;
            }
            else
            {
                dialogue.text = "";
                spoken = false;
            }
        }
    }
}
