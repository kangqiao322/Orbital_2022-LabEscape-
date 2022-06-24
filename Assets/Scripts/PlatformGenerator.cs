using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : GeneratorAbstract
    //this extends GeneratorAbstract class^
{
    private float interval;
    private float timePassed = 0f;
    private Vector3 spawnVector;

    //drag extra platform prefabs into this array field in the Unity GUI
    [SerializeField]
    public Transform[] platformArray;
    
    private void Update()
    {
        interval = UnityEngine.Random.Range(2f, 5f);
        timePassed += Time.deltaTime;

        if (timePassed > interval)
        {
            platformGeneration();
            timePassed = 0f;
        }
        
        // if (PlayerScript.isAlive)
        // {
        //     timePassed += Time.deltaTime;
        //
        //     if (timePassed > interval)
        //     {
        //         platformGeneration();
        //         timePassed = 0f;
        //     }
        // }

    }

    private void platformGeneration()
        //a method that handles platform prefabs
    {
        //randomly selects the platform to spawn
        int randInt = UnityEngine.Random.Range(0, platformArray.Length);

        spawnVector = new Vector3(30f, UnityEngine.Random.Range(22f, 24f), 0);
        RandomSpawn(0.8, platformArray[randInt], spawnVector);
        //1st value is probability. It is a parent class' method
    }
}