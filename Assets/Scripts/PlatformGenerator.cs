using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : GeneratorAbstract //this extends GeneratorAbstract class
{
    private float interval = 1f;
    private float timePassed = 0f;
    private Vector3 spawnVector;

    //make it public and drag the prefab into this field in the unity GUI
    [SerializeField] public Transform platform;

    private void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > interval)
        {
            spawnVector = new Vector3(30f, UnityEngine.Random.Range(12f, 30f));
            RandomSpawn(1, platform, spawnVector);
            timePassed = 0f;
        }
    }
}
