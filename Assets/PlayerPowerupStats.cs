using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerupStats : MonoBehaviour
{
    private float BubbleCount = 0f;
    private float MaxBubbleCount = 1f;

    public float getBubbleCount()
    {
        return this.BubbleCount;
    }

    public float getBubbleCountMax()
    {
        return this.MaxBubbleCount;
    }

    public void BubbleIncre()
    {
        this.BubbleCount += 1f;
    }

    public void BubbleDecre()
    {
        this.BubbleCount -= 1f;
    }


}
