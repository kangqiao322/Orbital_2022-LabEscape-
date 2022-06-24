using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public bool x2GemEffectActive = false;
    private float x2effectDuration = 10f;
    private float x2effectTimePassed = 0f;
    
    public bool hungerEffectActive = false;
    private float hungerEffectDuration = 10f;
    private float hungerEffectTimePassed = 0f;

    public bool bubbleActive = false;

    void Update()
    {
        if (x2GemEffectActive) //handles x2 gem effect active mechanic
        {
            x2effectTimePassed += Time.deltaTime;
            GhostGemScript.setGemMultiplierTo(2);
            
            if (x2effectTimePassed > x2effectDuration)
            {
                Debug.Log("x2 effect not active");
                x2GemEffectActive = false;
                x2effectTimePassed = 0f;
                GhostGemScript.setGemMultiplierTo(1);
            }
        }

        if (hungerEffectActive)
        {
            hungerEffectTimePassed += Time.deltaTime;
            //Debug.Log("hunger effect active");

            if (hungerEffectTimePassed > hungerEffectDuration)
            {
                Debug.Log("hunger effect not active");
                hungerEffectActive = false;
                hungerEffectTimePassed = 0f;
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
}
