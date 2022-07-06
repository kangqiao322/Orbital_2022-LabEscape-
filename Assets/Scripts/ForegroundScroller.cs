using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundScroller : MonoBehaviour
{
   public float scrollSpeed;
    public float maxSpeed;

    public GameManager gameManager;

    private Material renderer;
    private Vector2 savedOffset;

    private void Awake () {
        renderer = GetComponent<Renderer>().material;
    }

    void Update () {
        //correlate to game manager
    maxSpeed = gameManager.getMaxSpeed();
    scrollSpeed = gameManager.getSpeed();
    
    if (scrollSpeed < maxSpeed) 
    {
        scrollSpeed += Time.deltaTime;
    }
  

    savedOffset = new Vector2(scrollSpeed, 0);
    renderer.mainTextureOffset += savedOffset * Time.deltaTime;

    }
}
