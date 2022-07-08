using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    private float scrollSpeed;
    private float maxSpeed;

    [SerializeField] private GameManager gameManager;
    //[SerializeField] private Material[] materialArray = new Material[1];

    private Material currentMaterial;
    private Vector2 savedOffset;

    private void Start() {
        //currentMaterial = materialArray[0];
        //GetComponent<MeshRenderer>().material = currentMaterial;

        maxSpeed = gameManager.getMaxSpeed() * 0.001f;
        
        currentMaterial = GetComponent<MeshRenderer>().material;
    }

    void Update () {
        //correlate to game manager
        
        scrollSpeed = gameManager.getSpeed();

        if (scrollSpeed < maxSpeed) 
        {
            scrollSpeed += Time.deltaTime * 0.001f;
        }
        
        savedOffset = new Vector2(scrollSpeed, 0);
        currentMaterial.mainTextureOffset += savedOffset * Time.deltaTime;
    }


}
