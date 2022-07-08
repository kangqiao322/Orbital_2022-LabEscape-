using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScrolling : MonoBehaviour {
    private float scrollSpeed;
    private float maxSpeed;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private Material[] materialArray = new Material[1];

    private Material currentMaterial;
    private Vector2 savedOffset;

    private void Start() {
        // foreach (Material m in materialArray)
        // {
        //     queue.Enqueue(m); //FIFO
        // }

        // MeshRenderer a = GetComponent<MeshRenderer>();
        // Debug.Log(a.materials[1]);

        //GetComponent<MeshRenderer>().materials[0] = null;

        maxSpeed = gameManager.getMaxSpeed() * 0.001f;
        
        currentMaterial = materialArray[0];
        GetComponent<MeshRenderer>().material = currentMaterial;
        //makes the game background = all in 1 backgrounds material
    }

    void Update () {
        //correlate to game manager
        scrollSpeed = gameManager.getSpeed() * 0.001f;

        if (scrollSpeed < maxSpeed) 
        {
            scrollSpeed += Time.deltaTime * 0.001f;
        }
        

        // scrollSpeed = gameManager.getSpeed() * 0.001f;
        
        // timePassed += Time.deltaTime;
       
        savedOffset = new Vector2(scrollSpeed, 0);
        currentMaterial.mainTextureOffset += savedOffset * Time.deltaTime;
    }

    public void resetScrollOffset()
    {
        currentMaterial.mainTextureOffset = new Vector2(0, 0);
    }
}
