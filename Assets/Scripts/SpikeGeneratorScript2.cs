using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGeneratorScript2 : MonoBehaviour
{

    private float interval = 3f;
    private float timePassed = 0f;
    private Vector3 spawnVector = new Vector3(21f, 4.9f);
    private int noSpawnCount = 0;

    [SerializeField] public Transform spike;

    private void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > interval)
        {
            randomSpawn(0.7, spike, spawnVector);
            timePassed = 0f;
        }
    } 
    
    void randomSpawn(double probability, Transform spawnObject, Vector3 spawnPosition)
    {
        //randomly spawns spike with that probability
        //Spike is guaranteed to spawn in at most 3 tries

        if (noSpawnCount == 2)
        {
            Instantiate(spawnObject, spawnPosition, Quaternion.identity);
            noSpawnCount = 0;
        }
        else
        {
            float rand = UnityEngine.Random.Range(0f, 1f);

            if (rand < probability)
            {
                Debug.Log("Spawned spike");
                Instantiate(spawnObject, spawnPosition, Quaternion.identity);
                noSpawnCount++;
            }
            
        }
    }
}
