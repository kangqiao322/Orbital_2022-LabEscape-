using Unity.VisualScripting;
using UnityEngine;

public class HungerPowerUp : PowerUpAbstract
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
            if (powerUpManager.getHungerEffectStatus())
            {
                //if effect is still active and player picks up another hunger powerup
                //resets the effect time passed
                Debug.Log("reset hunger timer");
                powerUpManager.resetHungerEffectTimePassed(); 
            }
            
            AudioSource.PlayClipAtPoint(base.sound.clip, this.transform.position);
            Debug.Log("hunger effect active");
            powerUpManager.setHungerEffectActive(true); //effect handled by other class
            Destroy(this.gameObject);
        }
        else if (!otherCollider.CompareTag("wall"))
        {
            Debug.Log(gameObject + " touched " + otherCollider.gameObject + ", destroying itself...");
            Destroy(this.gameObject);
            FindObjectOfType<PowerUpGenerator>().increasePity();
        }
    }
}
