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
    public int score;
    public int combo;

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
