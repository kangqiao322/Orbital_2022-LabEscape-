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

    private BackgroundMusicInGame _backgroundMusicInGame;
    private ButtonPersistentSound _buttonPersistentSound;
    private PokemonSound _pokemonSound;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _backgroundMusicInGame = FindObjectOfType<BackgroundMusicInGame>();
        _buttonPersistentSound = FindObjectOfType<ButtonPersistentSound>();
        _pokemonSound = FindObjectOfType<PokemonSound>();
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
        if (_buttonPersistentSound != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
            _pokemonSound.pausePokemon();
        }
        
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        _backgroundMusicInGame.ResumeMusic();

    }

    void Pause ()
    {
        if (_buttonPersistentSound != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
            _pokemonSound.pausePokemon();
        }
        
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        _backgroundMusicInGame.PauseMusic();
    }
    
}
