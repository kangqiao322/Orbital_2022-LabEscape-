using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmSpawner : GeneratorAbstract
{
    private float interval;
    private float timePassed = 0f;
    private Vector3 spawnVector;

    

    //make it public and drag the prefab into this field in the unity GUI
    [SerializeField] private Transform enemy;

    private void Update()
    {
        if (base.hasGameEnded())
        {
            return;
        }
        //code stops here when game has ended, refer to parent method in GeneratorAbstract
        //this method is just so that i dont have to keep
        //importing GameManager in every single generator just to check if game has ended
        if (base.gameScore() > 5000) 
        {
            timePassed += Time.deltaTime;

            if (timePassed > interval)
            {
                interval = Random.Range(3f, 18f);
                spawnVector = new Vector3(15f, 16f);
                RandomSpawn(0.9, enemy, spawnVector);
                timePassed = 0f;
            }
        }

    }


    
}

