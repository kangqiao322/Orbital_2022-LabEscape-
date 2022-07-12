// using System;
// using UnityEngine;
// using System.Collections;
// using TMPro;
//
// public class FPS : MonoBehaviour {
//     
//     private TextMeshProUGUI FPSTxt;
//     
//     public int rangeInt;
//     public float updateInterval = 0.5F;
//     private float accum = 0;
//     private int frames = 0;
//     private float timeleft;
//     private string stringFps;
//
//     private void Start()
//     {
//         FPSTxt = GetComponent<TextMeshProUGUI>();
//     }
//
//     string label = "";
//     float count;
// 	
//     void Update()
//     {
//         timeleft -= Time.deltaTime;
//         accum += Time.timeScale / Time.deltaTime;
//         ++frames;
//         if (timeleft <= 0.0)
//         {
//             float fps = accum / frames;
//             string format = System.String.Format("{0:F2} FPS", fps);
//             FPSTxt.text = format;
//             timeleft = updateInterval;
//             accum = 0.0F;
//             frames = 0;
//         }
//     }
// }