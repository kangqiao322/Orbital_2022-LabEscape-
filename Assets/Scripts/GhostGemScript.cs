using System;
using TMPro;
using UnityEngine;

public class GhostGemScript : MonoBehaviour
//gemScore increases only when ghost gem touches the counter
//handles x2 gem effect
{
    private ScoreManager scoreManager;
    private static int gemMuliplier = 1; //has to be static no choice

    private Vector3 destinationVector = new Vector3(-19f, 29f, 0);

    private void Start()
    {
        //storing ScoreManager into a variable called scoreManager
        scoreManager = FindObjectOfType<ScoreManager>();

        //powerUpManager = FindObjectOfType<PowerUpManager>();
    }

    void Update()
    {
        var distanceToDestination = (destinationVector - this.transform.position).magnitude;
        
        if (distanceToDestination < 0.5)
        {
            scoreManager.increaseMainScoreBy(gemMuliplier); //1 gem = +1 main score
            scoreManager.increaseGemScoreBy(gemMuliplier);
            Destroy(this.gameObject);
        }
        else
        {
            flyToCounter();
        }
        
    }

    private void flyToCounter()
    {
        transform.position =
            Vector3.Lerp(transform.position, destinationVector, 1.5f * Time.deltaTime);
    }
    
    public static void setGemMultiplierTo(int multiplier)
    {
        gemMuliplier = multiplier;
    }
}
