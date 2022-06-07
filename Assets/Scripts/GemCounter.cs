using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemCounter : MonoBehaviour
//this script is a component of the gemCounter object in the hierarchy
{
    private TextMeshProUGUI gemCounterText;
    
    void Start()
    {
        gemCounterText = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        //Set the current number of gems to display
        if(gemCounterText.text != GemScript.totalGems.ToString(("0")))
        {
            gemCounterText.text = GemScript.totalGems.ToString(("0"));
        }
        
    }
}
