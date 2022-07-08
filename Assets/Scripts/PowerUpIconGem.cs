using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIconGem : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer rend;
    private PowerUpManager powerUpManager;
    private GameManager gameManager;

    public Animator animator;


    void Start()
    {
        rend = this.gameObject.GetComponent<SpriteRenderer>();
        powerUpManager = FindObjectOfType<PowerUpManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpManager.getGemStatusAlternate() == 1f)
        {
            //normal
           
            rend.enabled = true;
        }
        else if (powerUpManager.getGemStatusAlternate() == 2f)
        {
           
            animator.SetBool("GemEnding", true);
            rend.enabled = true;
        } 
        else if (powerUpManager.getGemStatusAlternate() == 0f)
        {
            //Debug.Log("WE HIT IT");
            animator.SetBool("GemEnding", false);
            rend.enabled = false;
        }
    }
}
