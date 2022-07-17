using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public bool x2GemEffectActive = false;
    private float x2effectDuration = 10f;
    public float x2effectTimePassed = 0f;
    
    public bool hungerEffectActive = false;
    private float hungerEffectDuration = 10f;
    public float hungerEffectTimePassed = 0f;

    public bool bubbleActive = false;

//0 is inactive
//1 for normal
//2 for pop
    private float bubbleAlternate = 0f;
    private float gemAlternate = 0f;
    private float hungerAlternate = 0f;
    private float warningTime = 5f;

  

    void Update()
    {
        if (x2GemEffectActive) //handles x2 gem effect active mechanic
        {
            gemAlternate = 1f;
            x2effectTimePassed += Time.deltaTime;
            GhostGemScript.setGemMultiplierTo(2);

            if (x2effectTimePassed > warningTime)
            {
                gemAlternate = 2f;
            }

             if (x2effectTimePassed <= warningTime)
            {
                gemAlternate = 1f;
            }
            
            if (x2effectTimePassed > x2effectDuration)
            {
                Debug.Log("x2 effect not active");
                x2GemEffectActive = false;
                x2effectTimePassed = 0f;
                GhostGemScript.setGemMultiplierTo(1);
                gemAlternate = 0f;
                
            }

            

        }
       

        if (hungerEffectActive)
        {
            hungerAlternate = 1f;
            hungerEffectTimePassed += Time.deltaTime;
            //Debug.Log("hunger effect active");

            if (hungerEffectTimePassed > warningTime)
            {
                hungerAlternate = 2f;
            }

             if (hungerEffectTimePassed <= warningTime)
            {
                hungerAlternate = 1f;
            }

            if (hungerEffectTimePassed > hungerEffectDuration)
            {
                Debug.Log("hunger effect not active");
                hungerEffectActive = false;
                hungerEffectTimePassed = 0f;
                hungerAlternate = 0f;
            }
            
        }
        
    }

    //x2 gem effect
    public bool getx2GemEffectStatus() //OOP principles time
    {
        return x2GemEffectActive;
    }
    
    public void setx2GemEffectActive(bool booleanVal)
    {
        x2GemEffectActive = booleanVal;
    }

    public void resetx2EffectTimePassed()
    {
        x2effectTimePassed = 0f;
    }
    
    
    //hunger effect
    public bool getHungerEffectStatus() //OOP principles time
    {
        return hungerEffectActive;
    }
    
    public void setHungerEffectActive(bool booleanVal)
    {
        hungerEffectActive = booleanVal;
    }

    public void resetHungerEffectTimePassed()
    {
        hungerEffectTimePassed = 0f;
    }
    
    //bubble effect
    public bool getBubbleStatus() //OOP principles time
    {
        return bubbleActive;
    }
    
    public void setBubbleActive(bool booleanVal)
    {
        bubbleActive = booleanVal;
    }


    public float getHungerTimePassed() 
    {
        return this.hungerEffectTimePassed;

    }

    public float getGemTimePassed() 
    {
        return this.x2effectTimePassed;
    }

    public float getGemDuration()
    {
        return this.x2effectDuration;
    }

    public float getHungerDuration()
    {
        return this.hungerEffectDuration;
    }
//these for animations, and when to  trigger them
    public float getBubbleStatusAlternate() //OOP principles time
    {
        return bubbleAlternate;
    }

    public void setBubbleAlternate(float number)
    {
        bubbleAlternate = number;
    }

    public float getGemStatusAlternate() //OOP principles time
    {
        return gemAlternate;
    }

    public void setGemAlternate(float number)
    {
        gemAlternate = number;
    }

    public float getHungerStatusAlternate() //OOP principles time
    {
        return hungerAlternate;
    }

    public void setHungerAlternate(float number)
    {
        hungerAlternate = number;
    }


    
    
}
