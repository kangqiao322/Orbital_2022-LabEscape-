using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberBarryEnemy : MonoBehaviour
{
        //do not freeze the x-axis

    private float speed;

    private GameManager gameManager;

    public GameObject tagger;

    private Vector3 taggerPos;

    //private Rigidbody2D enemyRB; //removed rigidbody on 26 June 2022
    private float timePassed = 0f;
    private float lifespan = 20f; //the amount of time left before destroyed
    // Start is called before the first frame update

    void Awake()
    {
        taggerPos = new Vector3(8, this.transform.position.y, this.transform.position.z);
        //assign GameManager to gameManager only once
        gameManager = FindObjectOfType<GameManager>();
        Instantiate(tagger, taggerPos, Quaternion.identity);
        
        
        //enemyRB = GetComponent<Rigidbody2D>();
        // platformRB.transform.localScale = new Vector3(10, 1, 0);
    }
    void Update()
    {
        if (gameManager.gameHasEnded())
        {
            return;
        }
        
        speed = gameManager.getSpeed() * 1.25f;
        
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
        /*
        if (!collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("enemy touched " + collision.gameObject + ", destroying enemy...");
            Destroy(this.gameObject);
        }
        */
    }
}
