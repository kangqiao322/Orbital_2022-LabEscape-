using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour //not in use for now
{

   public float speed;
//position when the screen exits camera
   public float endX;
//position when the screen spawns before camera
   public float startX;
   
   private GameManager gameManager;

   private void Awake()
   {
       //only calls this once
       gameManager = FindObjectOfType<GameManager>();
   }
   
   //fixed, use Update() instead of FixedUpdate()
    void Update()
    {
        speed = gameManager.getSpeed();
        //this transforms one screen to the other side once it exits to the camera, like a rotation of screens
        //delta time seems to be creating the gaps in the background
        // transform.Translate(Vector2.left * speed * Time.deltaTime);
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));

        if (transform.position.x <= endX)
        {
            transform.position = new Vector3(startX, transform.position.y, 0);
        }
        
    }


}
