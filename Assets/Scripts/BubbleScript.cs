using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    public GameObject pickupEffect;
    private GameManager gameManager;
    private float lifespan = 10f;
    private float speed;
    private float timePassed = 0f;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        speed = gameManager.getSpeed();
   
        //transform.Translate(new Vector3(-PlayerScript.gameSpeed * Time.deltaTime, 0, 0));
        //speed = displacement / deltaTime, and translation uses displacement
        
        timePassed += Time.deltaTime;
        
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
       
        
        if (timePassed > lifespan)
        {
            //Debug.Log("destroy " + this.gameObject);
            Destroy(this.gameObject);
            timePassed = 0f;
        }
    
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        PlayerPowerupStats PowerStatus = other.GetComponent<PlayerPowerupStats>();
        if(other.CompareTag("Player"))
        {
            if (PowerStatus.getBubbleCount() < PowerStatus.getBubbleCountMax())
            {
                Debug.Log(PowerStatus.getBubbleCount());
                //if have not gotten a bubble yet
                Pickup(other);
                PowerStatus.BubbleIncre();
                Destroy(this.gameObject);
            }
            else{
                //do nothing
               //animate bubble  
            }
            
        }
    }

    void Pickup(Collider2D player) 
    {
        Debug.Log("pickup");
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        PlayerScript stats = player.GetComponent<PlayerScript>();
        stats.playerHP += 1f;
      
    }
}
