using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGeneratorScript2 : GeneratorAbstract
{

    private float interval = 2f;
    private float timePassed = 0f;
    private Vector3 spawnVector = new Vector3(1f, 16.94f);

    //make it public and drag the prefab into this field in the unity GUI
    [SerializeField] public Transform spike;

    private void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > interval)
        {
            RandomSpawn(0.7, spike, spawnVector, 2);
            timePassed = 0f;
        }
    }
}
