using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScript : MonoBehaviour
{
    public GameObject Indicator;

    private int layer_mask;
    public float timeLeft;
    private float duration = 3f;



    private GameObject Target;
    //to check if enemy is within cameraview
    Renderer rd;

    void Start ()
    {
        rd = GetComponent<Renderer>();
        Target = GameObject.FindWithTag ("wall");
        layer_mask = LayerMask.GetMask("wall");
        timeLeft = duration;
    }
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (rd.isVisible == false)
        {
            if (Indicator.activeSelf == false)
            {
                Indicator.SetActive(true);
            }

            Vector2 direction = Target.transform.position - this.transform.position;

            RaycastHit2D ray = Physics2D.Raycast(this.transform.position, direction);

            if (ray.collider != null)
            {
                Debug.Log("RAY HIT");
                //indicator goes to that location
                Indicator.transform.position = ray.point;
            }
        }    
        
        else
        {
            if (Indicator.activeSelf == true)
            {
                Indicator.SetActive(false);
            }
             
        }

        if (timeLeft < 0f)
        {
            Destroy(Indicator);
            Destroy(this.gameObject);
          
        }
        

    }

}
