using UnityEngine;

public class SpikeScript : MonoBehaviour
{

    //do not freeze the x-axis
    //spike has tag of enemy instead of spike in unity
    
    private Rigidbody2D spikeRb; //this is private
    private float timePassed = 0f;
    private float lifespan = 5f; //the amount of time left before destroyed

    private GameManager gameManager;
    private float speed;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spikeRb = GetComponent<Rigidbody2D>();
        spikeRb.transform.localScale = new Vector3(2, 2, 0); //rescales the spike
    }
    
    
    void Update()
    {

        //im not sure why time.deltatime does not work to decrease the timebeforespdincr
        
        //spikeRb.velocity = new Vector2(-PlayerScript.gameSpeed, 0);


        speed = gameManager.getSpeed();

        timePassed += Time.deltaTime;
        
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));

        if (timePassed > lifespan)
        {
            //Debug.Log("destroy " + this.gameObject);
            Destroy(this.gameObject);
            timePassed = 0f;
        }
        
        // if (PlayerScript.isAlive)
        // {
        //     spikeRb.velocity = new Vector2(-15f, 0);
        //
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
