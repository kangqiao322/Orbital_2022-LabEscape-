using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScrolling : MonoBehaviour {
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
    maxSpeed = gameManager.getMaxSpeed() * 0.025f;
    scrollSpeed = gameManager.getSpeed() * 0.025f;
    
    if (scrollSpeed < maxSpeed) 
    {
        scrollSpeed += Time.deltaTime * 0.01f;
    }
  

    savedOffset = new Vector2(scrollSpeed, 0);
    renderer.mainTextureOffset += savedOffset * Time.deltaTime;

    }
}
