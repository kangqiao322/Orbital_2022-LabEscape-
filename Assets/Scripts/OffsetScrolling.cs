using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScrolling : MonoBehaviour {
    public float scrollSpeed;
    public float maxSpeed;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private Material[] materialArray = new Material[2];

    private Material currentMaterial;
    private Vector2 savedOffset;

    private float timeToNextBackground = 5f;
    private float timePassed = 0f;
    
    private Queue<Material> queue = new Queue<Material>();

    private void Start() {
        foreach (Material m in materialArray)
        {
            queue.Enqueue(m); //FIFO
        }

        // MeshRenderer a = GetComponent<MeshRenderer>();
        // Debug.Log(a.materials[1]);

        //GetComponent<MeshRenderer>().materials[0] = null;
        

        currentMaterial = queue.Dequeue(); //a queue is first in, first out FIFO
        GetComponent<MeshRenderer>().material = currentMaterial;
        //StartCoroutine(scrollBackground());
    }

    // private IEnumerator scrollBackground()
    // {
    //     maxSpeed = gameManager.getMaxSpeed() * 0.025f;
    //     scrollSpeed = gameManager.getSpeed() * 0.025f;
    //
    //     while (true)
    //     {
    //         if (scrollSpeed < maxSpeed) 
    //         {
    //             scrollSpeed += Time.deltaTime * 0.01f;
    //         }
    //
    //         savedOffset = new Vector2(scrollSpeed, 0);
    //         renderer.mainTextureOffset += savedOffset * Time.deltaTime;
    //     }
    //     
    //     // while (scrollSpeed < maxSpeed) 
    //     // {
    //     //     scrollSpeed += Time.deltaTime * 0.01f;
    //     //     savedOffset = new Vector2(scrollSpeed, 0);
    //     //     renderer.mainTextureOffset += savedOffset * Time.deltaTime;
    //     // }
    //     //
    //     // Debug.Log("maxSpeed now");
    //     //
    //     // savedOffset = new Vector2(scrollSpeed, 0);
    //     // renderer.mainTextureOffset += savedOffset * Time.deltaTime;
    // }

    void Update () {
        //correlate to game manager

        scrollSpeed = gameManager.getSpeed() * 0.001f;
        
        timePassed += Time.deltaTime;
       
        savedOffset = new Vector2(scrollSpeed, 0);
        currentMaterial.mainTextureOffset += savedOffset * Time.deltaTime;

        if (timePassed > timeToNextBackground)
        {
            timePassed = 0;
            queue.Enqueue(currentMaterial); //puts it back
            currentMaterial = queue.Dequeue(); //take new one
            GetComponent<MeshRenderer>().material = currentMaterial; //displays new one in unity
            //the material in mesh renderer is the one that is displaying the the background
        }
    
    }

    public void resetScrollOffset()
    {
        currentMaterial.mainTextureOffset = new Vector2(0, 0);
    }
}
