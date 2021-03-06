using System;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    //do not freeze the x-axis

    private float speed;

    private GameManager gameManager;

    //private Rigidbody2D enemyRB; //removed rigidbody on 26 June 2022
    private float timePassed = 0f;
    private float lifespan = 10f; //the amount of time left before destroyed

    
    void Awake()
    {
        //assign GameManager to gameManager only once
        gameManager = FindObjectOfType<GameManager>();
        
        
        //enemyRB = GetComponent<Rigidbody2D>();
        // platformRB.transform.localScale = new Vector3(10, 1, 0);
    }
    
    void Update()
    {
        if (gameManager.gameHasEnded())
        {
            return;
        }
        
        speed = gameManager.getSpeed();
        
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
        // Debug.Log(collision.collider.tag);
        
        if (!collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("enemy touched " + collision.gameObject + ", destroying enemy...");
            Destroy(this.gameObject);
        }
    }
}