using UnityEngine;

public class x2GemPowerUp : MonoBehaviour
{
    //power up script handles collision with player
    //not player script handles collision with power up
    
    private GameManager gameManager;
    private PowerUpManager powerUpManager;
    
    private float speed;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        powerUpManager = FindObjectOfType<PowerUpManager>();

        GetComponent<Collider2D>().isTrigger = true;
    }
    
    void OnTriggerEnter2D(Collider2D otherCollider) 
    {
        if (otherCollider.CompareTag("Player"))
        {
            if (powerUpManager.getx2GemEffectStatus())
            {
                //if x2 gem effect is still active and player picks up another x2 gem
                //resets the effect time passed
                powerUpManager.resetx2EffectTimePassed(); 
            }
            
            Debug.Log("x2 effect active");
            powerUpManager.setx2GemEffectActive(true); //effect handled by other class
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        speed = gameManager.getSpeed();
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
    }
}
