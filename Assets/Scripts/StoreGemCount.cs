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
        if (!PlayerPrefs.HasKey("totalGem"))
        {
            PlayerPrefs.SetInt("totalGem", 0);
        }
        
        totalGems = PlayerPrefs.GetInt("totalGem");

        gemScoreTxt = GetComponent<TextMeshProUGUI>();
        gemScoreTxt.text = totalGems.ToString("0");
    }
    
    void Update()
    {
        if (totalGems == PlayerPrefs.GetInt("totalGem"))
        {
            return;
        }
        
        totalGems = PlayerPrefs.GetInt("totalGem");
        gemScoreTxt.text = totalGems.ToString("0");
    }
}
