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
    private PokemonSound _pokemonSound;
    
    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        gameManager = FindObjectOfType<GameManager>();

        scroller = FindObjectOfType<OffsetScrolling>();
        scroller2 = FindObjectOfType<ForegroundScroller>();

        _backgroundMusicInGame = FindObjectOfType<BackgroundMusicInGame>();
        _buttonPersistentSound = FindObjectOfType<ButtonPersistentSound>();
        _pokemonSound = FindObjectOfType<PokemonSound>();
    }
    
    public void SetUp(float score) 
    {
        gameObject.SetActive(true);
        pointsTxt.text = score.ToString("0") + " Points";
    }

    public void RestartButton() 

    {
        if (_buttonPersistentSound != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
            _pokemonSound.pausePokemon();
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
        if (_buttonPersistentSound != null)
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
    
    //responsible for the green pause button 
    public void ResumeButton() 
    {
        if (_buttonPersistentSound != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
            _pokemonSound.pausePokemon();
        }

        gameObject.SetActive(false);
        gameManager.startGame();
        Time.timeScale = 1f;
        _backgroundMusicInGame.ResumeMusic();
    }

    //responsible for the green pause button 
    public void PauseButton() 
    {
        if (_buttonPersistentSound != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
            _pokemonSound.pausePokemon();
        }
        

        gameObject.SetActive(true);
        //gameManager.startGame();
        Time.timeScale = 0f;
        _backgroundMusicInGame.PauseMusic();
    }

    public void ExitButton()
    {
        if (_buttonPersistentSound != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
        }

        Application.Quit();
    }

}
