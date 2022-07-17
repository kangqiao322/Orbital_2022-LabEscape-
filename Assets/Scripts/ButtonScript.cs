using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
//for handling buttons in the main menu, shop and settings screens only
{
    private OffsetScrolling offsetScrolling;
    private ButtonPersistentSound _buttonPersistentSound;
    private PokemonSound _pokemonSound;
    
    private void Awake()
    {
        _buttonPersistentSound = FindObjectOfType<ButtonPersistentSound>();
        _pokemonSound = FindObjectOfType<PokemonSound>();
        
        offsetScrolling = FindObjectOfType<OffsetScrolling>();
    }

    public void PlayButton()
    {
        //this is ONLY when the game DOES NOT start from main menu
        //since the button persistent object only spawns in the main menu
        //there might be a problem with the green pause button for some reason no sound gets played
        if (_buttonPersistentSound != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
            _pokemonSound.pausePokemon();
        }

        //Load the Biome1 scene, ordering in File > Build Settings
        SceneManager.LoadScene("Biome1");
        
        //for now no reset scrolling, cause null pointer error but game still runs tho
        //offsetScrolling.resetScrollOffset();
    }

    public void ShopButton()
    {
        if (_buttonPersistentSound != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
        }
        
        SceneManager.LoadScene("Shop");
    }
    
    public void SettingsButton()
    {
        if (_buttonPersistentSound != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
        }
        
        SceneManager.LoadScene(3);
    }

    public void MainMenuButton()
    {

        if (_buttonPersistentSound != null)
        {
            //button click sound
            _buttonPersistentSound.playNormalClick();
        }
        
        //Load the main menu scene
        SceneManager.LoadScene(0);
    }
}
