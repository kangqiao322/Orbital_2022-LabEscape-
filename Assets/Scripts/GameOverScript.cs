using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//this is a button manager actually during gameplay

public class GameOverScript : MonoBehaviour
{

    public TextMeshProUGUI pointsTxt;

    private ScoreManager scoreManager;
    private GameManager gameManager;
    private OffsetScrolling offsetScrolling;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        gameManager = FindObjectOfType<GameManager>();
        offsetScrolling = FindObjectOfType<OffsetScrolling>();
    }
    
    public void SetUp(float score) 
    {
        gameObject.SetActive(true);
        pointsTxt.text = score.ToString("0") + " Points";
    }

    public void RestartButton() 

    {
        //reload the active scene instead of biome1
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameManager.startGame();
        scoreManager.setTotalGems(0);
        offsetScrolling.resetScrollOffset();
        Time.timeScale = 1f;
    }

    public void MainMenuButton() 
    {
        SceneManager.LoadScene("MainMenu");
        gameManager.startGame();
        scoreManager.setTotalGems(0);
        offsetScrolling.resetScrollOffset();
        Time.timeScale = 1f;
    }

    public void ResumeButton() 
    {
        gameObject.SetActive(false);
        gameManager.startGame();
        Time.timeScale = 1f;
    }

    public void PauseButton() 
    {
        gameObject.SetActive(true);
        //gameManager.startGame();
        Time.timeScale = 0f;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
