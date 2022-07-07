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
    maxSpeed = gameManager.getMaxSpeed() * 0.001f;
    scrollSpeed = gameManager.getSpeed() * 0.001f;
    //980, 21
    //578, 26.2
    //maxSpeed = gameManager.getMaxSpeed() * 0.0009f;
    //scrollSpeed = gameManager.getSpeed() * 0.0009f;
    /*
    if (scrollSpeed < maxSpeed)
    {
        scrollSpeed += Time.deltaTime * 0.011f;
        //scrollSpeed += Time.deltaTime * 0.0009f;
    }
  
*/
    savedOffset = new Vector2(scrollSpeed, 0);
    renderer.mainTextureOffset += savedOffset * Time.deltaTime;

    }

    public void resetGround()
    {
        renderer.mainTextureOffset = new Vector2(0, 0);
    }
}
