using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePowerUp : PowerUpAbstract
    //this extends PowerUpAbstract class for movement and lifespan
{
    //public GameObject pickupEffect;
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
            Debug.Log("bubble active");
            powerUpManager.setBubbleActive(true); //effect handled by other class
            //to facilitate anim
            powerUpManager.setBubbleAlternate(1f);
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
