using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScrolling : MonoBehaviour {
    public float scrollSpeed;
    public float maxSpeed = 2f;

    public GameManager gameManager;

    private Renderer renderer;
    private Vector2 savedOffset;

    void Start () {
        renderer = GetComponent<Renderer> ();
    }

    void Update () {
        //correlate to game manager
    maxSpeed = gameManager.getMaxSpeed() * 0.1f;
    /*
    if (scrollSpeed < maxSpeed) 
    {
        scrollSpeed += Time.deltaTime * 0.01f;
    }
    */
    scrollSpeed = gameManager.getSpeed() * 0.025f;

    //scrollSpeed = gameManager.getSpeed() * 0.1f;
	float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
	Vector2 offset = new Vector2 (x, 0);
	renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}