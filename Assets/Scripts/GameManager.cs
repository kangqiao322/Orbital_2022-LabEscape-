using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// this manages the various scenes and restart etc
public class GameManager : MonoBehaviour
{
    public GameOverScript GameOverScreen;

    public void GameOverScene(float score) {
        //this generates the game over screen
        GameOverScreen.SetUp(score);
    }

    bool gameHasEnded = false;
    public float restartDelay  = 1f;
    // Start is called before the first frame update
    
    
    public void GameOver ()
    {
        //this instantly restarts the game, might not need it anymore
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAMEOVER");
            //Invoke("Restart", restartDelay);
        }
    }

    void Restart () 
    {
         //this instantly restarts the game, might not need it anymore
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
