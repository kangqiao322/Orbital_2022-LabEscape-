using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
     public GameObject[] enemyPatterns;
     private float timeBtwSpawn;
     public float startTimeBtwSpawn;
     public float decreaseTime;
     public float minTime = 0.65f;
   
    // // Update is called once per frame
     void Update()
     {
         if (timeBtwSpawn <= 0)
         {
             int rand = Random.Range(0, enemyPatterns.Length);
             Instantiate(enemyPatterns[rand], transform.position, Quaternion.identity);
             timeBtwSpawn = startTimeBtwSpawn;
             if (startTimeBtwSpawn > minTime) {
             startTimeBtwSpawn -= decreaseTime;
             }
         }
         else {
             timeBtwSpawn -= Time.deltaTime;
         }
     }
}
