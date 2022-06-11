using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

   public float speed;
//position when the screen exits camera
   public float endX;
//position when the screen spawns before camera
   public float startX;
   
   private GameManager gameManager;
   


    // Update is called once per frame
    void FixedUpdate()
    {
        speed = FindObjectOfType<GameManager>().getSpeed();
        //this transforms one screen to the other side once it exits to the camera, like a rotation of screens
        //delta time seems to be creating the gaps in the background
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
        }
    
 
    }


}
