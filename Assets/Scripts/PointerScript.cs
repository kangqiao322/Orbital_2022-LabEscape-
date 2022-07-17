using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{

    public GameObject Indicator;
    Renderer rd;


    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
        if (rd.isVisible == false)
        {
            if (Indicator.activeSelf == false)
            {
                Indicator.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rd.isVisible)
        {
            Indicator.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("CamBox"))
         {
            Indicator.transform.position = new Vector3(10, 10, 0);
         }
    }
}
