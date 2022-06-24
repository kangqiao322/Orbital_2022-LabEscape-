// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
//
// public class GroundScroller : MonoBehaviour
// {
//     private GameManager gameManager;
//     private RawImage img;
//     private float speed;
//     
//     void Start()
//     {
//         //only calls this once
//         gameManager = FindObjectOfType<GameManager>();
//         img = GetComponent<RawImage>();
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//
//         speed = gameManager.getSpeed();
//         
//         img.uvRect = new Rect(img.uvRect.position + new Vector2(-speed,0) * Time.deltaTime
//             , img.uvRect.size);
//         
//     }
// }
