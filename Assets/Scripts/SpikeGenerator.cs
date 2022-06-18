// using UnityEngine;
//
// public class SpikeGenerator : MonoBehaviour
// {
//     // Start is called before the first frame update
//     public GameObject spike;
//
//     public float MinSpeed;
//     public float MaxSpeed;
//     public float currentSpeed;
//
//     public float SpeedMultiplier;
//     
//     public void generateSpike()
//     {
//        GameObject clone = Instantiate(spike, transform.position, Quaternion.identity);
//
//        //Destroy(clone, 8f);
//     }
//
//
//     void Awake()
//     {
//        currentSpeed = MinSpeed;
//        generateSpike(); 
//     }
//
//     public void GenerateSpikeRandomiser() 
//     {
//         float randomWait = Random.Range(1f, 6f);
//         Invoke("generateSpike", randomWait);
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         if(currentSpeed < MaxSpeed)
//         {
//             currentSpeed += SpeedMultiplier;
//         }
//     }
// }
