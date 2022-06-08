using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : GeneratorAbstract //this extends GeneratorAbstract class
{
    private float interval = 1f;
    private float timePassed = 0f;
    private Vector3 spawnVector;

    //make it public and drag the prefab into this field in the unity GUI
    //to add more platforms to spawn, copy and paste another line
    //then add your platform into platformArray below 
    [SerializeField] public Transform platform;
    [SerializeField] public Transform platformWithGems;
    [SerializeField] public Transform doublePlatWithGemsJumpArc;

    private Transform[] platformArray;

    private void Awake()
    {
        //an array of platform objects
        platformArray = new Transform[] {
            platform,
            platformWithGems,
            doublePlatWithGemsJumpArc };
    }

    private void Update()
    {
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
        spawnVector = new Vector3(20f, UnityEngine.Random.Range(20f, 25f));
        
        RandomSpawn(0.8, platformArray[randInt], spawnVector);
    }
}
