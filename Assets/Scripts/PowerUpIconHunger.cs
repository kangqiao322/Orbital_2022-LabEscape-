using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIconHunger : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer rend;
    private PowerUpManager powerUpManager;
    //private GameManager gameManager;
    
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
        if (powerUpManager.getHungerStatusAlternate() == 1f)
        {
            //normal
           
            rend.enabled = true;
        }
        else if (powerUpManager.getHungerStatusAlternate() == 2f)
        {
           
            animator.SetBool("HungerEnding", true);
            rend.enabled = true;
        } 
        else if (powerUpManager.getHungerStatusAlternate() == 0f)
        {
            Debug.Log("WE HIT IT");
            animator.SetBool("HungerEnding", false);
            rend.enabled = false;
        }
    }
}
