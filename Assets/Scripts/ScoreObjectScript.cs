using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreObjectScript : MonoBehaviour
//this script handles the behaviour of the floating score when eating enemy
//and moving and fading out
//this gave me cancer
{
    private TextMeshPro pointsText;
    
    // Start is called before the first frame update
    void Start()
    { 
        //due to some problem cannot give the prefab fonts first idk why
        pointsText = GetComponentInChildren<TextMeshPro>();
        pointsText.font = Resources.Load<TMP_FontAsset>("ThaleahFat_TTF SDF");
        pointsText.text = "+100";
        pointsText.fontSize = 15;
        pointsText.color = new Color(255, 215, 0, 0.7f); //Gold colour with 0.7 alpha
        
        StartCoroutine(FadeTextToZeroAlpha(pointsText));
    }
    
    private IEnumerator FadeTextToZeroAlpha(TextMeshPro text)
     {
         while (text.color.a > 0.0f)
         {
             text.transform.position += 0.005f * Vector3.up;
             
             text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 3));
             yield return null;
         }
         
         yield return new WaitForSeconds(3);
         Destroy(this.gameObject);
     }

}
