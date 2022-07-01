using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeneratorAbstract : MonoBehaviour
{
    private int noSpawnCount = 0;
    private GameManager gameManager;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    
    protected bool hasGameEnded()
    {
        //this method is just so that i dont have to keep importing GameManager
        //in every single generator just to check if game has ended
        
        return this.gameManager.gameHasEnded();
    }

    protected void RandomSpawn(double probability, Transform spawnObject, Vector3 spawnPosition, int maxNoSpawnCount)
    {
        //randomly spawns with that probability
        //Is guaranteed to spawn once in at most maxNoSpawnCount tries

        if (noSpawnCount >= maxNoSpawnCount)
        {
            Instantiate(spawnObject, spawnPosition, Quaternion.identity);
            noSpawnCount = 0;
        }
        else
        {
            float rand = UnityEngine.Random.Range(0f, 1f);

            if (rand < probability)
            {
                //Debug.Log("Spawned " + spawnObject);
                Instantiate(spawnObject, spawnPosition, Quaternion.identity);
                noSpawnCount++;
            }
        }
    }

    protected void RandomSpawn(double probability, Transform spawnObject, Vector3 spawnPosition)
    {
        //Overloaded method
        
        float rand = UnityEngine.Random.Range(0f, 1f);

        if (rand < probability)
        {
            //Debug.Log("Spawned " + spawnObject);
            Instantiate(spawnObject, spawnPosition, Quaternion.identity);
        }

    }

}
