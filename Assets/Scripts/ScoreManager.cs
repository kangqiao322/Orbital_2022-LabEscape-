using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;


public class ScoreManager : MonoBehaviour
//this script handles the main score, highscore and gem score
//this script is a component of the ScoreManager object in the canvas
{
    private TextMeshProUGUI[] scoreArray;
    private TextMeshProUGUI mainScoreTxt;
    private TextMeshProUGUI highScoreTxt;
    private TextMeshProUGUI gemScoreTxt;
    
    private PlayerScript player;
    
    private float score;
    private float currentHighscore;

    void Awake()
    {
        //recursively finds all TextMeshProUGUI in its children and children's children
        scoreArray = GetComponentsInChildren<TextMeshProUGUI>();
        mainScoreTxt = scoreArray[0];
        highScoreTxt = scoreArray[1];
        gemScoreTxt = scoreArray[3]; //the 2nd one is the "x" txt so ignore
        
        player = FindObjectOfType<PlayerScript>();
        
        //uncomment this if you want to reset your highscore
        //PlayerPrefs.DeleteKey("highScore");
        
        
        //gets current high score from player prefs and displays it in game
        currentHighscore = PlayerPrefs.GetFloat("highScore");
        highScoreTxt.text = "HIGHSCORE: " + currentHighscore.ToString("0");
    }

    private void Update()
    {
        //this is for displaying score and highscore
        if (player.isAlive)
        {
            score += Time.deltaTime * 50;
            mainScoreTxt.text = "SCORE: " + score.ToString(("0")) ;
            
            //this is for maintaining highscore and saving it 
            if (score > currentHighscore)
            {
                currentHighscore = score;
                highScoreTxt.text = "HIGHSCORE: " + currentHighscore.ToString("0");
                PlayerPrefs.SetFloat("highScore", currentHighscore);
            }
        }
        
        //Set the current number of gems to display
        gemScoreTxt.text = GemScript.totalGems.ToString(("0"));
    }
    
    public void increaseMainScoreBy(int increment)
    {
        this.score += increment;
    }

    public float getScore()
    {
        return this.score;
    }

    public float getHighScore() 
    {
        return this.currentHighscore;
    }
}