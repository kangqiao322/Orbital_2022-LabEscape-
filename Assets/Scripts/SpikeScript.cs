using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    //contains information on lifespan, velocity, and spawn rate

    //do not freeze the x-axis
    //spike has tag of enemy instead of spike in unity
    
    private Rigidbody2D spikeRb; //this is private
    private float timePassed = 0f;
    private float lifespan = 10f; //the amount of time left before destroyed
    
    void Start()
    {
        spikeRb = GetComponent<Rigidbody2D>();
        spikeRb.transform.localScale = new Vector3(5, 5, 0); //rescales the spike
    }
    
    
    void Update()
    {
        spikeRb.velocity = new Vector2(-50f, 0);

        timePassed += Time.deltaTime;
        if (timePassed > lifespan)
        {
            Debug.Log("destroy " + this.gameObject);
            Destroy(this.gameObject);
            timePassed = 0f;
        }
    }


}
