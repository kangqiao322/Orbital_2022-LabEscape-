using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// this manages the various scenes and restart etc
public class GameManager : MonoBehaviour
{

//make this adjustable first
    public float maxSpeed;
    public float currentSpeed;
    public float speedIncrMultiplier;
    public float timeUntilSpawnRateIncrease;
    public float timeCounter;

    public GameOverScript GameOverScreen;
    public static bool gameHasEnded = false;


    public void GameOverScene(float score) {
        //this generates the game over screen

        GameManager.gameHasEnded = true;
        GameOverScreen.SetUp(score);
    }

    
    //public float restartDelay  = 1f;
    // Start is called before the first frame update
    
    
    public void GameOver()
    {
        //this instantly restarts the game, might not need it anymore
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAMEOVER");
            //Invoke("Restart", restartDelay);
        }
    }

    public void Restart() 
    {
         //this instantly restarts the game, might not need it anymore
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     
    //this is for increasing speed
    private void Update()
    {
        timeUntilSpawnRateIncrease -= Time.deltaTime;
        /*
        if (timeUntilSpawnRateIncrease < 1 && currentSpeed <= maxSpeed) 
        {
            currentSpeed += speedIncrMultiplier;
            timeUntilSpawnRateIncrease = timeCounter;
        }
        */

        if (currentSpeed <= maxSpeed) 
        {
            currentSpeed += speedIncrMultiplier;
        }
    
        
        
    }
    
    public float getSpeed()
    {
        return this.currentSpeed;
    }

    public float getMaxSpeed()
    {
        return this.maxSpeed;
    }

}
