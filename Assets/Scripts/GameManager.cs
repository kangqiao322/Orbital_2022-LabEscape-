using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// this manages the various scenes and restart etc
public class GameManager : MonoBehaviour
{

    public float  maxSpeed = 50f;
    public float currentSpeed = 16f;
    public float speedIncrMultiplier = 1f;
    private float timeUntilSpawnRateIncrease = 2f;

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
     
    
    private void Update()
    {
        timeUntilSpawnRateIncrease -= Time.deltaTime;

        if (timeUntilSpawnRateIncrease < 1 && currentSpeed <= maxSpeed) 
        {
            currentSpeed += speedIncrMultiplier;
            timeUntilSpawnRateIncrease = 2f;
        }
    }

    public float getSpeed()
    {
        return this.currentSpeed;
    }

}
