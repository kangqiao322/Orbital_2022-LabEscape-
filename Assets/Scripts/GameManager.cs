using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// this manages the various scenes and restart etc
public class GameManager : MonoBehaviour
{

//make this adjustable first
    private float maxSpeed = 25f;
    private float currentSpeed = 10f;
    private float speedIncrMultiplier = 0.8f;
    private float timeUntilSpawnRateIncrease = 3f;
    private float timeCounter = 3f;

    public GameOverScript GameOverScreen;
    public static bool gameHasEnded = false;


    public void GameOverScene(float score) {
        //this generates the game over screen

        GameManager.gameHasEnded = true;
        GameOverScreen.SetUp(score);
    }

    public void ResetGameData()
    {
        currentSpeed = 0f;
        speedIncrMultiplier = 0f;
    }

     
    //this is for increasing speed
    private void Update()
    {
        //Debug.Log(currentSpeed);
        timeUntilSpawnRateIncrease -= Time.deltaTime;
        
        if (timeUntilSpawnRateIncrease < 0 && currentSpeed + speedIncrMultiplier <= maxSpeed) 
        {
            currentSpeed += speedIncrMultiplier;
            timeUntilSpawnRateIncrease = timeCounter;
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
