using UnityEngine;

public class SpikeScript : MonoBehaviour
{

    public SpikeGenerator spikeGenerator;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left *spikeGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("nextLine"))
        {
            spikeGenerator.GenerateSpikeRandomiser();
        }
       
      
       
    }
    
}
