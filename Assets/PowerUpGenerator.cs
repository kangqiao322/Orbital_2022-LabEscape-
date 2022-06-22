using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : GeneratorAbstract
    //this extends GeneratorAbstract class^
{
    private float interval;
    private float timePassed = 0f;
    private Vector3 spawnVector;

    //drag extra platform prefabs into this array field in the Unity GUI
    [SerializeField]
    public Transform[] PowerUpArray;
    
    private void Update()
    {
        interval = UnityEngine.Random.Range(20f, 50f);
        timePassed += Time.deltaTime;

        if (timePassed > interval)
        {
            powerUpGeneration();
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

    private void powerUpGeneration()
        //a method that handles platform prefabs
    {
        //randomly selects the platform to spawn
        int randInt = UnityEngine.Random.Range(0,  PowerUpArray.Length);

        spawnVector = new Vector3(80f, UnityEngine.Random.Range(22f, 24f), 0);
        RandomSpawn(0.8,  PowerUpArray[randInt], spawnVector);
        //1st value is probability. It is a parent class' method
    }
}
