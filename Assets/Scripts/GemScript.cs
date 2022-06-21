using UnityEngine;

public class GemScript : MonoBehaviour
//this script handles the behaviour of all gems, including counting of total gems
//however displaying of gem score is in ScoreManager
{
    //freeze z-axis
    
    private ScoreManager scoreManager;
    private float timePassed = 0f;
    private float lifespan = 10f; //the amount of time left before destroyed
    
    private static int gemMuliplier = 1;
    public static int totalGems = 0; 
    
    private void Start()
    {
        //storing ScoreManager into a variable called scoreManager
        scoreManager = FindObjectOfType<ScoreManager>();

        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }
    
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Destroy the gem if any Object with tag Player comes into contact with it
        if (otherCollider.CompareTag("Player"))
        {
            scoreManager.increaseMainScoreBy(gemMuliplier); //1 gem = +1 main score
            totalGems += gemMuliplier;
            Destroy(this.gameObject);
        }
    }
    
    
    void Update()
    {
        //gem does not require velocity
        
        timePassed += Time.deltaTime;
        if (timePassed > lifespan)
        {
            //Debug.Log("destroy " + this.gameObject);
            Destroy(this.gameObject);
            timePassed = 0f;
        }
        
        // if (PlayerScript.isAlive)
        // {
        //     timePassed += Time.deltaTime;
        //     if (timePassed > lifespan)
        //     {
        //         Debug.Log("destroy " + this.gameObject);
        //         Destroy(this.gameObject);
        //         timePassed = 0f;
        //     }
        // }
    }

    public static void setGemMultiplierTo(int multiplier)
    {
        gemMuliplier = multiplier;
    }


}
