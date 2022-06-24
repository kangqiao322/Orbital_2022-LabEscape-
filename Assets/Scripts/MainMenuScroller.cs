using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScroller : MonoBehaviour
{
    private RawImage img;
    private float x = 0.05f, y = 0f;

    private void Start()
    {
        img = GetComponent<RawImage>();
    }
    
    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x,y) * Time.deltaTime, img.uvRect.size);
    }
}
