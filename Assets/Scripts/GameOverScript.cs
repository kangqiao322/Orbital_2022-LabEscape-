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

    private OffsetScrolling scroller;
    private ForegroundScroller scroller2;

    private BackgroundMusicInGame _backgroundMusicInGame;
    
    private ButtonPersistentSound _buttonPersistentSound;
    
    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        gameManager = FindObjectOfType<GameManager>();

        scroller = FindObjectOfType<OffsetScrolling>();
        scroller2 = FindObjectOfType<ForegroundScroller>();

        _backgroundMusicInGame = FindObjectOfType<BackgroundMusicInGame>();
        _buttonPersistentSound = FindObjectOfType<ButtonPersistentSound>();
    }
    
    public void SetUp(float score) 
    {
        gameObject.SetActive(true);
        pointsTxt.text = score.ToString("0") + " Points";
    }

    public void RestartButton() 

    {
        if (ButtonPersistentSound.Instance != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
        }

        //reload the active scene instead of biome1
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameManager.startGame();
        scoreManager.setTotalGems(0);
        Time.timeScale = 1f;

        scroller.resetScrollOffset();
        scroller2.resetGround();
    }

    public void MainMenuButton() 
    {
        if (ButtonPersistentSound.Instance != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
        }

        SceneManager.LoadScene("MainMenu");
        gameManager.startGame();
        scoreManager.setTotalGems(0);
        Time.timeScale = 1f;
        
        scroller.resetScrollOffset();
        scroller2.resetGround();
    }

    public void ResumeButton() 
    {
        if (ButtonPersistentSound.Instance != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
        }

        gameObject.SetActive(false);
        gameManager.startGame();
        Time.timeScale = 1f;
        _backgroundMusicInGame.ResumeMusic();
    }

    public void PauseButton() 
    {
        if (ButtonPersistentSound.Instance != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
        }

        gameObject.SetActive(true);
        //gameManager.startGame();
        Time.timeScale = 0f;
        _backgroundMusicInGame.PauseMusic();
    }

    public void ExitButton()
    {
        if (ButtonPersistentSound.Instance != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
        }

        Application.Quit();
    }

}
