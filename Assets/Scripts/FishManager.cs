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
    public MindGrid mindGrid;
    public ScoreManager scoreManager;

    // put effects here? guess so
    public GameObject catchEffect;
    public GameObject splashEffect;

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
            if (GameManager.Instance.itemBought[0])
                mindGrid.updateGrid(fishQueue[1]);
            fishActive = true;
        }

        curFish.Swim();

        if (!GameManager.Instance.Paused) // check if game is paused
        {
            checkInput();
            updateFish();
        }
    }

    private Direction direction;

    void checkInput()
    {
        // hard code for now // make sure the keys can be rebound, make the keys global
        // MAKE SURE TO FIX THIS!!!!
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            direction = Direction.Up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            direction = Direction.Down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            direction = Direction.Left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            direction = Direction.Right;
        }

        if (direction == curFish.getInput().getDirection())
        {
            curFish.removeInput();
            inputGrid.removeInput();

            direction = Direction.None;
        }
        else if (direction != Direction.None && direction != curFish.getInput().getDirection() && !GameManager.Instance.itemBought[2])
        {
            fishVanish();
        }
    }

    void updateFish()
    {
        // if player inputs are successful
        if (curFish.inputs.Count <= 0)
        {
            fishCatch();
        }
        else if (curFish.transform.position.x >= 6)
        {
            fishVanish();
        }
    }

    void fishCatch()
    {
        scoreManager.UpdateScore(curFish.score);
        updateFishCaught();
        playCEffect();
        playSEffect();
        curFish.Catch(); // catch fish, add to fish dictionary
        inputGrid.clearInputs(); // clear inputs from grid
        mindGrid.clearInputs();
        fishQueue.RemoveAt(0); // make sure to remove from grid otherwise it will never update
        fishActive = false;
    }

    void fishVanish()
    {
        scoreManager.ResetCombo();
        playSEffect();
        curFish.Vanish();
        inputGrid.clearInputs(); // clear inputs from grid
        mindGrid.clearInputs();
        fishQueue.RemoveAt(0); // make sure to remove from grid otherwise it will never update
        fishActive = false;
        direction = Direction.None;
    }

    void updateQueue()
    { 
        if (fishQueue.Count <= 2)
        {
            if (GameManager.Instance.combo == 64)
                fishQueue.Add(GameManager.Instance.fishSelection[23]);
            else if (GameManager.Instance.combo > 42)
                fishQueue.Add(GameManager.Instance.fishSelection[UnityEngine.Random.Range((int)GameManager.Instance.fishSelection.Count / 3 * 2, (int)GameManager.Instance.fishSelection.Count - 1)]);
            else if (GameManager.Instance.combo > 21)
                fishQueue.Add(GameManager.Instance.fishSelection[UnityEngine.Random.Range((int)GameManager.Instance.fishSelection.Count / 3, (int)GameManager.Instance.fishSelection.Count / 3 * 2)]);
            else
                fishQueue.Add(GameManager.Instance.fishSelection[UnityEngine.Random.Range(0, (int)GameManager.Instance.fishSelection.Count / 3)]);
        }
    }

    // play effect for catching fish
    void playCEffect()
    {
        GameObject CE = Instantiate(catchEffect, curFish.transform.position, curFish.transform.rotation);
        CE.GetComponent<CatchEffect>().fishSprite = curFish.sprite;
        Destroy(CE, 1.5f);
    }

    // play splash effect
    void playSEffect()
    {
        GameObject CE = Instantiate(splashEffect, curFish.transform.position + new Vector3(0f, .4f, 0f), curFish.transform.rotation);
        Destroy(CE, .3f);
    }

    // this sucks!
    void updateFishCaught()
    {
        int count = 0;
        int index = 0;

        foreach (Fish curFUCKINGFISH in GameManager.Instance.fishSelection)
        {
            if (curFUCKINGFISH.type == curFish.type)
            {
                index = count;
            }
            count++;
        }

        GameManager.Instance.fishCaught[index] = true;
    }
}
