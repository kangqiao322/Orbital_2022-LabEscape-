using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIconDisplay : MonoBehaviour
{

    private PowerUpManager powerUpManager;
    private GameManager gameManager;
    public SpriteRenderer rend;

    private float timer;

    private float delay;

    //IEnumerator delayCoroutine;
    

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rend = this.gameObject.GetComponent<SpriteRenderer>();
        powerUpManager = FindObjectOfType<PowerUpManager>();
    }
   
    // Update is called once per frame
    void Update()
    {
        if (powerUpManager.getBubbleStatusAlternate() == 1f)
        {
            Debug.Log("BUBBLE HIT");
            rend.enabled = true;
            animator.SetBool("BubbleOn", true);
        }
        else if (powerUpManager.getBubbleStatusAlternate() == 2f)
        {
            Debug.Log("POP BUBBLE");
            animator.SetBool("BubbleOn", false);
            StartCoroutine(DelayBubble());
        }
        

    }


    IEnumerator DelayBubble()
    {
        yield return new WaitForSeconds(0.5f);
        rend.enabled = false;
    }  
}
