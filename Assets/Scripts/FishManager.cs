using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    
    List<Fish> fishQueue = new List<Fish>();
    private Fish curFish;
    private bool fishActive;
    public InputGrid inputGrid;
    public ScoreManager scoreManager;

    // put effects here? guess so
    public GameObject catchEffect;

    // Start is called before the first frame update
    void Start()
    {
        fishQueue.Add(GameManager.Instance.fishSelection[0]);
        scoreManager.ResetCombo();
    }

    // Update is called once per frame
    void Update()
    {
        updateQueue(); // add fish to queue if queue is less than 3

        if (!fishActive) // if no fish active, add next in queue
        {
            curFish = Instantiate(fishQueue[0], this.transform); //create pointer to current fish on screen
            inputGrid.updateGrid(curFish); //update grid with fish inputs
            fishActive = true;
        }

        curFish.Swim();

        if (!GameManager.Instance.Paused) // check if game is paused
        {
            checkInput();
            updateFish();
        }
    }

    void checkInput()
    {
        // hard code for now // make sure the keys can be rebound, make the keys global
        // MAKE SURE TO FIX THIS!!!!
        if (Input.GetKeyDown(KeyCode.UpArrow) && curFish.getInput().getDirection() == Direction.Up)
        {
            curFish.removeInput();
            inputGrid.removeInput();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && curFish.getInput().getDirection() == Direction.Down)
        {
            curFish.removeInput();
            inputGrid.removeInput();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && curFish.getInput().getDirection() == Direction.Left)
        {
            curFish.removeInput();
            inputGrid.removeInput();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && curFish.getInput().getDirection() == Direction.Right)
        {
            curFish.removeInput();
            inputGrid.removeInput();
        }
    }

    void updateFish()
    {
        // if player inputs are successful
        if (curFish.inputs.Count <= 0)
        {
            scoreManager.UpdateScore(curFish.score);
            playCEffect();
            curFish.Catch(); // catch fish, add to fish dictionary
            inputGrid.clearInputs(); // clear inputs from grid
            fishQueue.RemoveAt(0); // make sure to remove from grid otherwise it will never update
            //Debug.Log(fishQueue[0]);
            fishActive = false;
        }
        else if (curFish.transform.position.x >= 6)
        {
            scoreManager.ResetCombo();
            curFish.Vanish();
            inputGrid.clearInputs(); // clear inputs from grid
            fishQueue.RemoveAt(0); // make sure to remove from grid otherwise it will never update
            //Debug.Log(fishQueue[0]);
            fishActive = false;
        }
    }

    void updateQueue()
    { 
        if (fishQueue.Count <= 2)
        {
            fishQueue.Add(GameManager.Instance.fishSelection[UnityEngine.Random.Range(0, GameManager.Instance.fishSelection.Count)]);
        }
    }

    // play effect for catching fish
    void playCEffect()
    {
        GameObject CE = Instantiate(catchEffect, curFish.transform.position, curFish.transform.rotation);
        CE.GetComponent<CatchEffect>().fishSprite = curFish.sprite;
        Destroy(CE, 1.5f);
    }
}
