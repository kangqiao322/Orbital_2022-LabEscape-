using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberSpawner : GeneratorAbstract
{
    //interval is mananing the time inbewteen spawns
    private float interval;
    private float timePassed = 0f;
    private Vector3 spawnVector;
    private int rando;
    

    //make it public and drag the prefab into this field in the unity GUI
    [SerializeField] private Transform[] enemy;
    private void Update()
    {
        
        if (base.hasGameEnded())
        {
            return;
        }
        
   
        //code stops here when game has ended, refer to parent method in GeneratorAbstract
        //this method is just so that i dont have to keep
        //importing GameManager in every single generator just to check if game has ended
        if (base.gameScore() > 3000)
        {

        timePassed += Time.deltaTime;

        if (timePassed > interval)
        {
            rando = Random.Range(0, enemy.Length);
            interval = Random.Range(1f, 18f);
            spawnVector = new Vector3(120f, UnityEngine.Random.Range(20f, 25f));
            RandomSpawn(0.95, enemy[rando], spawnVector);
            /*
            if (rando == 0)
            {
                RandomSpawn(0.7, enemy[0], spawnVector);
            }

            if (rando == 1)
            {
                RandomSpawn(1, enemy[1], spawnVector);
            }
            */
            timePassed = 0f;
        }
        }

    }
}
