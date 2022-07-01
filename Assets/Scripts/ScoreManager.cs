using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;


public class ScoreManager : MonoBehaviour
//this script handles the main score, highscore and gem score
//this script is a component of the ScoreManager object in the canvas
//
{
    private TextMeshProUGUI[] scoreArray;
    private TextMeshProUGUI mainScoreTxt;
    private TextMeshProUGUI highScoreTxt;
    private TextMeshProUGUI gemScoreTxt;
    
    private GameManager gameManager;
    
    private float score;
    private float currentHighscore;
    //this is to speed up score incrementation
    private float scoreIncrement;

    private int gemCount = 0;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        //recursively finds all TextMeshProUGUI in its children and children's children
        scoreArray = GetComponentsInChildren<TextMeshProUGUI>();
        mainScoreTxt = scoreArray[0];
        highScoreTxt = scoreArray[1];
        gemScoreTxt = scoreArray[3]; //the 2nd one is the "x" txt so ignore

        //uncomment this if you want to reset your highscore and total gems
        //PlayerPrefs.SetFloat("highScore", 0);
        //PlayerPrefs.SetInt("totalGem", 0);
        
        
        //gets current high score from player prefs and displays it in game
        currentHighscore = PlayerPrefs.GetFloat("highScore");
        highScoreTxt.text = "HIGHSCORE: " + currentHighscore.ToString("0");
    }

    private void Update()
    {
        //this is for displaying score and highscore
        if (!gameManager.gameHasEnded())
        {
            scoreIncrement = gameManager.getSpeed();
            score += Time.deltaTime * scoreIncrement * 2;
        }
        
        //the code below here runs even after player dies
        //since score need to be updated when the gems fly to the counter
        //score is incremented by ghost gem script and should be updated in the game UI
        
        mainScoreTxt.text = "SCORE: " + score.ToString(("0"));
        gemScoreTxt.text = gemCount.ToString(("0"));
        
        //this is for maintaining highscore and saving it 
        if (score > currentHighscore)
        {
            currentHighscore = score;
            highScoreTxt.text = "HIGHSCORE: " + currentHighscore.ToString("0");
            PlayerPrefs.SetFloat("highScore", currentHighscore);
        }
    }
    
    public void increaseMainScoreBy(int increment)
    {
        this.score += increment;
    }
    
    public void increaseGemScoreBy(int n)
    {
        gemCount += n;
    }

    public void setTotalGems(int n)
    {
        gemCount = n;
    }

    public float getScore()
    {
        return this.score;
    }

    public float getHighScore() 
    {
        return this.currentHighscore;
    }

    public int getCurrentGemScore()
    {
        return this.gemCount;
    }


}