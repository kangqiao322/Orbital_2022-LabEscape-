using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGeneratorScript2 : GeneratorAbstract
{

    private float interval = 2f;
    private float timePassed = 0f;
    //now it spawns outside the screen which is intended

    //make it public and drag the prefab into this field in the unity GUI
    [SerializeField] public Transform spike;

    private void Update()
    {
        
        timePassed += Time.deltaTime;
            
        if (timePassed > interval)
        {
            var spawnVector = new Vector3(UnityEngine.Random.Range(12f, 40f), 17.4f);
            RandomSpawn(0.8, spike, spawnVector, 2);
            timePassed = 0f;
        }
        
        // if (PlayerScript.isAlive)
        // {
        //     timePassed += Time.deltaTime;
        //     
        //     if (timePassed > interval)
        //     {
        //         RandomSpawn(0.7, spike, spawnVector, 2);
        //         timePassed = 0f;
        //     }
        // }

    }
}