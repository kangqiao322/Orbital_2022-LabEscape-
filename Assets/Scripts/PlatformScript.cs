using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    //do not freeze the x-axis

    private float timePassed = 0f;
    private float lifespan = 3f; //the amount of time left before destroyed
    private float speed;

    private GameManager gameManager;
    
    void Awake()
    {
        // platformRB = GetComponent<Rigidbody2D>();
        // platformRB.transform.localScale = new Vector3(10, 1, 0);
        
    }
    
    
    void Update()
    {
        speed = FindObjectOfType<GameManager>().getSpeed();
   
        timePassed += Time.deltaTime;
        
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
       
        
        if (timePassed > lifespan)
        {
            Debug.Log("destroy " + this.gameObject);
            Destroy(this.gameObject);
            timePassed = 0f;
        }
    }

}