using UnityEngine;

public class SpikeScript : MonoBehaviour
{

    //do not freeze the x-axis
    //spike has tag of enemy instead of spike in unity
    
    private Rigidbody2D spikeRb; //this is private
    private float timePassed = 0f;
    private float lifespan = 10f; //the amount of time left before destroyed

    private GameManager gameManager;
    private float speed;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spikeRb = GetComponent<Rigidbody2D>();
    }
    
    
    void Update()
    {
        if (gameManager.gameHasEnded())
        {
            return;
        }

        //im not sure why time.deltatime does not work to decrease the timebeforespdincr
        
        //spikeRb.velocity = new Vector2(-PlayerScript.gameSpeed, 0);


        speed = gameManager.getSpeed() * 0.98f;

        timePassed += Time.deltaTime;
        
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));

        if (timePassed > lifespan)
        {
            //Debug.Log("destroy " + this.gameObject);
            Destroy(this.gameObject);
            timePassed = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platformUnderside"))
        {
            Destroy(this.gameObject);
        }
    }


}
