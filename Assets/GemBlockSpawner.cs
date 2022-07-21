using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBlockSpawner : GeneratorAbstract
{
    private float interval;
    private float timePassed = 0f;
    private Vector3 spawnVector;
    private int rando;
   
    

    //make it public and drag the prefab into this field in the unity GUI
    [SerializeField] private Transform[] blocks;

  
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
            rando = Random.Range(0, blocks.Length);
            interval = Random.Range(1f, 10f);
            spawnVector = new Vector3(50f, UnityEngine.Random.Range(20f, 28f));
            RandomSpawn(1, blocks[rando], spawnVector);
           
            timePassed = 0f;
        }
        

    }
}
