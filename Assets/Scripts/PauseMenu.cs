using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this may be redundant as i already havea pause screen, this is pause when esc is pressed
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update () {
        
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.gameHasEnded)
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
