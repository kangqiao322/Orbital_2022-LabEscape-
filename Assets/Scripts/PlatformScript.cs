using System;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    //do not freeze the x-axis

    private float speed;

    private GameManager gameManager;

    private Rigidbody2D platformRB; //this is private
    private float timePassed = 0f;
    private float lifespan = 15f; //the amount of time left before destroyed

    
    void Start()
    {
        //assign GameManager to gameManager only once
        gameManager = FindObjectOfType<GameManager>();
        
        platformRB = GetComponent<Rigidbody2D>();
        // platformRB.transform.localScale = new Vector3(10, 1, 0);
        
    }

    void Update()
    {
        if (gameManager.gameHasEnded())
        {
            return;
        }
        
        speed = gameManager.getSpeed() ;
   
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.collider.tag);
        
        //the problem is that the collider for platform is so small
        //platforms can overlap with each other
        
        if (collision.gameObject.CompareTag("ground") ||
            collision.gameObject.CompareTag("gem"))
        {
            Destroy(this.gameObject);
        }
    }

}
