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
    private Transform[] platformArray;

    
    
    private void Update()
    {

        if (base.hasGameEnded())
        {
            return;
        }
        //code stops here when game has ended, refer to parent method in GeneratorAbstract
        //this method is just so that i dont have to keep
        //importing GameManager in every single generator just to check if game has ended

        interval = UnityEngine.Random.Range(2.5f, 5f);
        timePassed += Time.deltaTime;

        if (timePassed > interval)
        {
            platformGeneration();
            timePassed = 0f;
        }
        

    }

    private void platformGeneration()
        //a method that handles platform prefabs
    {
        //randomly selects the platform to spawn
        int randInt = UnityEngine.Random.Range(0, platformArray.Length);

        switch (randInt)
        {
            case 6:
                spawnVector = new Vector3(20f, UnityEngine.Random.Range(22f, 22f), 0);
                break;
            case 7:
                spawnVector = new Vector3(20f, UnityEngine.Random.Range(22f, 22f), 0);
                break;
            default:
                spawnVector = new Vector3(20f, UnityEngine.Random.Range(22f, 24f), 0);
                break;
        }
        
        RandomSpawn(0.8, platformArray[randInt], spawnVector);
        //1st value is probability. It is a parent class' method
    }
}