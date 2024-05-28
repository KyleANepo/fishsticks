using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    // these will all be global variables!
    public List<Fish> fishSelection; // full list of fish to be chosen from
    public List<bool> fishCaught;
    public List<bool> itemBought;
    public int score;
    public int combo;
    public int bait = 1;
    public int maxCombo = 0;

    // Pause menu stuff. Maybe put in something else if considering different scenes?
    public GameObject PauseMenu;
    public bool Paused;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < fishCaught.Count; i++)
        {
            fishCaught[i] = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Paused)
        {
            PauseGame();
        } 
        else if (Input.GetKeyDown(KeyCode.Escape) && Paused) 
        {
            ResumeGame();
        }
    }

    public void ButtonPause()
    {
        if (!Paused)
        {
            PauseGame();
        }
        else if (Paused)
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        Paused = true;
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }

    private void ResumeGame()
    {
        Paused = false;
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
    }


}
