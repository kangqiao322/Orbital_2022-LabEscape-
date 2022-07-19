using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGeneratorScript2 : GeneratorAbstract
{

    private float interval;
    private float timePassed = 0f;
    //now it spawns outside the screen which is intended

    //make it public and drag the prefab into this field in the unity GUI
    [SerializeField] private Transform[] spike;

    private int rand;



    private void Update()
    {
        if (base.hasGameEnded())
        {
            return;
        }
        //code stops here when game has ended, refer to parent method in GeneratorAbstract
        //this method is just so that i dont have to keep
        //importing GameManager in every single generator just to check if game has ended
        
        timePassed += Time.deltaTime;
            
        if (timePassed > interval)
        {
            interval = Random.Range(2f, 10f);
            rand = Random.Range(0, spike.Length);
            if (rand == 0) 
            {
            var spawnVector = new Vector3(UnityEngine.Random.Range(12f, 40f), 17.4f);
            RandomSpawn(0.65, spike[rand], spawnVector, 2);
            timePassed = 0f;
            }
            else
            {
            var spawnVector = new Vector3(UnityEngine.Random.Range(12f, 40f), 17f);
            RandomSpawn(0.65, spike[rand], spawnVector, 2);
            timePassed = 0f;
            }
        }

    }
}