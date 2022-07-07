using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreGemCount : MonoBehaviour
{
    private int totalGems;
    private TextMeshProUGUI gemScoreTxt;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("totalGem"))
        {
            totalGems = PlayerPrefs.GetInt("totalGem");
        }
        else
        {
            PlayerPrefs.SetInt("totalGem", 0);
            totalGems = 0;
        }

        gemScoreTxt = GetComponent<TextMeshProUGUI>();
        gemScoreTxt.text = totalGems.ToString("0");
    }
    
    void Update()
    {
        gemScoreTxt.text = totalGems.ToString("0");
    }
}
