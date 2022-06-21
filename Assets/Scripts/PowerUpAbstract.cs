using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAbstract : MonoBehaviour
//this class can actually be the parent class for most moving objects
//but have not implemented it yet
{
    private GameManager gameManager;
    
    private float timePassed = 0f;
    private float lifespan = 5f; //the amount of time left before destroyed
    private float speed;
    
    public virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        speed = gameManager.getSpeed();
        
        timePassed += Time.deltaTime;
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));

        if (timePassed > lifespan)
        {
            Destroy(this.gameObject);
            timePassed = 0f;
        }
    }
}
