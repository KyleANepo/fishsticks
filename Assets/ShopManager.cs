using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShopManager : MonoBehaviour
{
    public GameObject ShopMenu;
    public GameObject keeper;
    public GameObject ShopButton;

    public GameObject poofEffect;
    public TextMeshProUGUI dialogue;

    public ScoreUI scoreUI;

    private bool Ready;
    private bool Active;

    public CameoManager CameoManager;

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

    // gurantee a cameo spawn on the first exit from shop
    bool firstCameo = false;
    public void ButtonSetShop()
    {
        if (!GameManager.Instance.Paused)
        {
            if (!Active)
            {
                DisplayShop();
                CameoManager.DeleteCameo();
            }
            else if (Active)
            {
                DisableShop();
                if (!firstCameo)
                {
                    CameoManager.SetCameo(); 
                    firstCameo = true;
                }
                else
                    CameoManager.RandomCameo();
            }
        }
    }

    void DisplayShop()
    {
        ShopButton.SetActive(false);
        keeper.SetActive(true);
        ShopMenu.SetActive(true);
        Active = true;
    }

    void DisableShop()
    {
        ShopButton.SetActive(true);
        keeper.SetActive(false);
        ShopMenu.SetActive(false);
        Active = false;
    }

    bool firstEye = true;
    public void BuyEye()
    {
        if (firstEye)
        {
            dialogue.text = "Open your minds eye, and see the next fish to bite the hook... for only 500!";
            firstEye = false;
        }
        else if (GameManager.Instance.itemBought[0])
        {
            dialogue.text = "Sorry bud, one mind's eye per person! It's hard to get ahold of em...";
        }
        else if (GameManager.Instance.score >= 500 && !GameManager.Instance.itemBought[0])
        {
            GameManager.Instance.score -= 500;
            scoreUI.UpdateElement();
            GameManager.Instance.itemBought[0] = true;
            dialogue.text = "I just need you to sign a waiver before I attune your mind's eye... nothing shady, I promise...";
        }
        else
        {
            dialogue.text = "You're krilling me! 500 dollars is reasonable for a mind's eye of this quality!";
        }
    }

    bool firstBait = true;
    public void BuyBait()
    {
        if (firstBait)
        {
            dialogue.text = "It's ofishal; this is the best bait money can buy you! ...500 for it.";
            firstBait = false;
        }
        else if (GameManager.Instance.score >= 500)
        {
            GameManager.Instance.score -= 500;
            scoreUI.UpdateElement();
            GameManager.Instance.itemBought[1] = true;
            GameManager.Instance.bait += 1;
            dialogue.text = "Heh heh, thank you... the fish should stick around muuuch longer now...";
        }
        else
        {
            dialogue.text = "You're krilling me! 500 dollars is reasonable for bait of this quality!";
        }
    }

    bool firstRobot = true;
    public void BuyRobot()
    {
        if (firstRobot)
        {
            dialogue.text = "Something about this egg... 3000 for it.";
            firstRobot = false;
        }
        else if (GameManager.Instance.itemBought[2])
        {
            dialogue.text = "Dude, just go to Mmart or something...";
        }
        else if (GameManager.Instance.score >= 3000 && !GameManager.Instance.itemBought[2])
        {
            GameManager.Instance.score -= 3000;
            scoreUI.UpdateElement();
            GameManager.Instance.itemBought[2] = true;
            dialogue.text = "...seriously? Um... here you go, man...";
        }
        else
        {
            dialogue.text = "Yeah, I get it...";
        }
    }
}
