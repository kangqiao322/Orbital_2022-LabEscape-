using UnityEngine;

public class GemScript : MonoBehaviour
//this script handles the behaviour of all gems, including counting of total gems
{
    //freeze z-axis
    
    private PlayerScript player;
    private float timePassed = 0f;
    private float lifespan = 4f; //the amount of time left before destroyed
    
    public static int totalGems = 0; 
    
    private void Start()
    {
        //accessing PlayerScript from this variable "player"
        player = FindObjectOfType<PlayerScript>();

        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }
    
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Destroy the gem if any Object with tag Player comes into contact with it
        if (otherCollider.CompareTag("Player"))
        {
            player.increaseMainScoreBy(1); //1 gem = +1 main score
            totalGems++;
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


}
