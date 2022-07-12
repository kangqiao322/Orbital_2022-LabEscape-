using UnityEngine;

public class GemScript : MonoBehaviour
//this script handles the behaviour of all gems, including counting of total gems
//however displaying of gem score is in ScoreManager
{
    //freeze z-axis

    private GameManager gameManager;
    private float timePassed = 0f;
    private float lifespan = 10f; //the amount of time left before destroyed

    [SerializeField] private Transform ghostGem;
    private AudioSource gemCollect;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        gemCollect = GetComponent<AudioSource>();
        gemCollect.playOnAwake = false;
        //Debug.Log(gemCollect);

        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }
    
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Instantiate ghost gem if any Object with tag Player comes into contact with it
        if (otherCollider.CompareTag("Player"))
        {
            Instantiate(ghostGem, this.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(gemCollect.clip, this.transform.position);
            Destroy(this.gameObject);
        }
    }
    
    
    void Update()
    {
        //gem does not require velocity
        
        if (gameManager.gameHasEnded())
        {
            return;
        }
        
        timePassed += Time.deltaTime;
        if (timePassed > lifespan)
        {
            //Debug.Log("destroy " + this.gameObject);
            Destroy(this.gameObject);
            timePassed = 0f;
        }
    }
    
}
