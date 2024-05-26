using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShopManager : MonoBehaviour
{
    public GameObject ShopMenu;
    public GameObject ShopButton;

    public GameObject poofEffect;

    private bool Ready;
    private bool Active;

    // Update is called once per frame
    void FixedUpdate()
    {
        poofShop();
    }

    void poofShop()
    {
        if (GameManager.Instance.combo >= 10 && !Ready)
        {
            ShopButton.SetActive(true);
            Ready = true;
            GameObject CE = Instantiate(poofEffect, transform.position, transform.rotation);
            Destroy(CE, .2f);
        }
    }

    public void ButtonSetShop()
    {
        if (!GameManager.Instance.Paused)
        {
            if (!Active)
            {
                DisplayShop();
            }
            else if (Active)
            {
                DisableShop();
            }
        }
    }

    void DisplayShop()
    {
        ShopButton.SetActive(false);
        ShopMenu.SetActive(true);
        Active = true;
    }

    void DisableShop()
    {
        ShopButton.SetActive(true);
        ShopMenu.SetActive(false);
        Active = false;
    }

    public void BuyEye()
    {
        GameManager.Instance.itemBought[0] = true;
    }

    public void BuyBait()
    {
        GameManager.Instance.itemBought[1] = true;
    }

    public void BuyRobot()
    {
        GameManager.Instance.itemBought[2] = true;
    }
}
