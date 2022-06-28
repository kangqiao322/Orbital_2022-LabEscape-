using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this may be redundant as i already havea pause screen, this is pause when esc is pressed
public class PauseMenu : MonoBehaviour
{
    private bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update () {
        
        if (Input.GetKeyDown(KeyCode.Escape) && !gameManager.gameHasEnded())
            //if game over screen displays then cannot display pause menu
        {
            if (GameIsPaused)
            {
                Resume();
            } else 
            {
                Pause();
            }
        }

    }

    void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }
    
}
