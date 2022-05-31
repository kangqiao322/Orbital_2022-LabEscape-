using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartButton()
    {
        //Load the next scene, ordering in File > Build Settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void MainMenuButton()
    {
        //Load the main menu scene
        SceneManager.LoadScene(0);
    }
}
