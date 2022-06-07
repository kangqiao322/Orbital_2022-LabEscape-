using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//this is for all the buttons actually

public class GameOverScript : MonoBehaviour
{

    public TextMeshProUGUI pointsTxt;
    // Start is called before the first frame update
    public void SetUp(float score) 
    {
        gameObject.SetActive(true);
        pointsTxt.text = score.ToString("0") + " Points";
    }

    public void RestartButton() 

    {
        //reload the active scene instead of biome1
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.gameHasEnded = false;
        GemScript.totalGems = 0;
        Time.timeScale = 1f;
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("MainMenu");
        GameManager.gameHasEnded = false;
        GemScript.totalGems = 0;
        Time.timeScale = 1f;
    }

    public void ResumeButton() {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseButton() {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

}
