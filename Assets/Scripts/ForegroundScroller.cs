using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundScroller : MonoBehaviour
{
    private float scrollSpeed;

    [SerializeField] private GameManager gameManager;

    private Material rend;
    private Vector2 savedOffset;

    private void Awake () {
        rend = GetComponent<Renderer>().material;
    }

    void Update () {
        scrollSpeed = gameManager.getSpeed() * 0.001f;
    
        //980, 21
        //578, 26.2

        savedOffset = new Vector2(scrollSpeed, 0);
        rend.mainTextureOffset += savedOffset * Time.deltaTime;
    }

    public void resetGround()
    {
        rend.mainTextureOffset = new Vector2(0, 0);
    }
}
