using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : GeneratorAbstract
    //this extends GeneratorAbstract class^
{
    //time before 1st powerup is spawned
    private float interval = 20f;
    private float timePassed = 0f;
    private Vector3 spawnVector;
    private int pity = 0; //compensation if power up spawns in other objects

    //drag extra platform prefabs into this array field in the Unity GUI
    [SerializeField] private Transform[] PowerUpArray;
    
    private void Update()
    {
        if (base.hasGameEnded())
        {
            return;
        }
        //code stops here when game has ended, refer to parent method in GeneratorAbstract
        //this method is just so that i dont have to keep
        //importing GameManager in every single generator just to check if game has ended

        //interval = UnityEngine.Random.Range(2f, 5f); //testing for now 
        timePassed += Time.deltaTime;

        if (timePassed > interval)
        {
            //time for next power up to spawn
            interval = UnityEngine.Random.Range(5f, 10f); //prob = 0.4 to spawn tho
            powerUpNtimes(1 + pity);
            timePassed = 0f;
        }
    }

    private void powerUpNtimes(int n)
    {
        while (n > 0)
        {
            powerUpGeneration();
            n--;
        }

        pity = 0;
    }

    private void powerUpGeneration()
    {
        //randomly selects the powerup to spawn
        int randInt = UnityEngine.Random.Range(0, PowerUpArray.Length);

        spawnVector = new Vector3(UnityEngine.Random.Range(10f, 70f), UnityEngine.Random.Range(17f, 25f), 0);
        RandomSpawn(0.4, PowerUpArray[randInt], spawnVector);
        //1st value is probability. It is a parent class' method
    }

    public void increasePity()
    {
        pity++;
    }
}
