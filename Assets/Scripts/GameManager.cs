   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    //this manages the various scenes and restart etc
    //this also manages global total gems between game sessions
public class GameManager : MonoBehaviour
{

//make this adjustable first
    private float maxSpeed = 25f;
    private float currentSpeed = 15f;
    private float speedIncrMultiplier = 0.8f;
    private float timeUntilSpawnRateIncrease = 3f;
    private float timeCounter = 3f;

    public GameOverScript GameOverScreen;
    private bool gameEnded = false;

    private GameManager gameManager;
    
    //stores the global total gems, persists between game sessions
    private int totalGems;

    private void Start()
    {
        if (PlayerPrefs.HasKey("totalGem"))
        {
            totalGems = PlayerPrefs.GetInt("totalGem");
        }
        else
        {
            PlayerPrefs.SetInt("totalGem", 0);
            totalGems = 0;
        }

        gameManager = GetComponent<GameManager>();
        
        Debug.Log("current global gems = " + totalGems);
    }


    public void GameOverScene(float score)
    {
        gameEnded = true;
        GameOverScreen.SetUp(score); //this generates the game over screen
        
        //only when player dies, total global gems is updated and stored.
        totalGems += FindObjectOfType<ScoreManager>().getCurrentGemScore();
        PlayerPrefs.SetInt("totalGem", totalGems);
    }

    public void ResetGameData()
    {
        currentSpeed = 0f;
        speedIncrMultiplier = 0f;
    }

     
    //this is for increasing speed
    private void Update()
    {
        if (gameManager.gameHasEnded() == true)
        {
            currentSpeed = 0;
            return;
        }
        
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

    public bool gameHasEnded()
    {
        return this.gameEnded;
    }

    public void endGame()
    {
        gameEnded = true;
    }

     public void startGame()
    {
        gameEnded = false;
    }

}
