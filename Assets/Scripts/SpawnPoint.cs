using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
   public GameObject enemy;

    void Start()
    {
        GameObject enemyIns = Instantiate(enemy, transform.position, Quaternion.identity);
        Destroy(enemyIns, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
