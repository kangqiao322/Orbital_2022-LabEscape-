using UnityEngine;

public class GemScript : MonoBehaviour
//this script handles the behaviour of all gems, including counting of total gems
{
    //freeze z-axis
    
    private Rigidbody2D gemRB; //this is private
    private float timePassed = 0f;
    private float lifespan = 4f; //the amount of time left before destroyed
    
    public static int totalGems = 0; 
    
    private void Start()
    {
        gemRB = GetComponent<Rigidbody2D>();
        
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
        
        //may not need this
        //gemRB.transform.localScale = new Vector3(7, 7, 0);
    }
    
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Destroy the gem if Object tagged Player comes in contact with it
        if (otherCollider.CompareTag("Player"))
        {
            totalGems++;
            //Debug.Log("You currently have " + GemScript.totalGems + " Gems.");
            Destroy(this.gameObject);
        }
    }
    
    
    void Update()
    {
        //gem does not require velocity
        
        timePassed += Time.deltaTime;
        if (timePassed > lifespan)
        {
            Debug.Log("destroy " + this.gameObject);
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
