using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
//for handling buttons in the main menu, shop and settings screens only
{
    public void PlayButton()
    {
        //Load the Biome1 scene, ordering in File > Build Settings
        SceneManager.LoadScene("Biome1");
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
