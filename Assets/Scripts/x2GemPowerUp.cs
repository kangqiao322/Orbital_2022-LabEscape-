using UnityEngine;

public class x2GemPowerUp : PowerUpAbstract
    //this extends PowerUpAbstract class for movement and lifespan
{
    //power up script handles collision with player
    //not player script handles collision with power up
    
    private PowerUpManager powerUpManager;
    
    public override void Start()
    {
        base.Start();
        powerUpManager = FindObjectOfType<PowerUpManager>();

        GetComponent<Collider2D>().isTrigger = true;
    }
    
    public override void Update()
    {
        base.Update();
    }
    
    void OnTriggerEnter2D(Collider2D otherCollider) 
    {
        if (otherCollider.CompareTag("Player"))
        {
            if (powerUpManager.getx2GemEffectStatus())
            {
                //if x2 gem effect is still active and player picks up another x2 gem
                //resets the effect time passed
                Debug.Log("resetting timer");
                powerUpManager.resetx2EffectTimePassed(); 
            }
            
            Debug.Log("x2 effect active");
            powerUpManager.setx2GemEffectActive(true); //effect handled by other class
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log(gameObject + " touched " + otherCollider.gameObject + ", destroying itself...");
            Destroy(this.gameObject);
            FindObjectOfType<PowerUpGenerator>().increasePity();
        }
    }
}
