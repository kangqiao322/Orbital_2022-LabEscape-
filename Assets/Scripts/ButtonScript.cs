using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
//for handling buttons in the main menu, shop and settings screens only
{
    private OffsetScrolling offsetScrolling;
    private void Start()
    {
        offsetScrolling = FindObjectOfType<OffsetScrolling>();
    }

    public void PlayButton()
    {
        //Load the Biome1 scene, ordering in File > Build Settings
        SceneManager.LoadScene("Biome1");
        
        //for now no reset scrolling, cause null pointer error but game still runs tho
        //offsetScrolling.resetScrollOffset();
    }

    public void ShopButton()
    {
        SceneManager.LoadScene("Shop");
    }

    public void MainMenuButton()
    {
        //Load the main menu scene
        SceneManager.LoadScene(0);
    }
}
