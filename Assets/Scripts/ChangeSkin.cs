using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public AnimatorOverrideController redAnim;
    public AnimatorOverrideController goldAnim;
    public AnimatorOverrideController greenAnim;
    public AnimatorOverrideController silverAnim;
    public AnimatorOverrideController greyAnim;
    public AnimatorOverrideController yellowAnim;
    public AnimatorOverrideController orangeAnim;
    public AnimatorOverrideController purpleAnim;
    public AnimatorOverrideController brownAnim;
    public AnimatorOverrideController pinkAnim;
    public AnimatorOverrideController turqAnim;
    public AnimatorOverrideController ghostAnim;
    public AnimatorOverrideController galaxyAnim;
    // Start is called before the first frame update
     public void GoldSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = goldAnim as RuntimeAnimatorController;
    }

    public void RedSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = redAnim as RuntimeAnimatorController;
    }

    public void GreenSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = greenAnim as RuntimeAnimatorController;
    }

    public void SilverSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = silverAnim as RuntimeAnimatorController;
    }

    public void GalaxySkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = galaxyAnim as RuntimeAnimatorController;
    }

    public void PinkSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = pinkAnim as RuntimeAnimatorController;
    }
    
    public void GreySkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = greyAnim as RuntimeAnimatorController;
    }

    public void OrangeSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = orangeAnim as RuntimeAnimatorController;
    }

    public void BrownSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = brownAnim as RuntimeAnimatorController;
    }

    public void PurpleSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = purpleAnim as RuntimeAnimatorController;
    }

    public void GhostSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = ghostAnim as RuntimeAnimatorController;
    }

    public void TurqSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = turqAnim as RuntimeAnimatorController;
    }

    public void YellowSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = yellowAnim as RuntimeAnimatorController;
    }

    public void Update()
    {
        if (PlayerPrefs.GetInt("wearing") == 0)
        {

        }
        else if (PlayerPrefs.GetInt("wearing") == 1)
        {
            YellowSkin();
        }
        else if (PlayerPrefs.GetInt("wearing") == 2)
        {
            RedSkin();
        }
        else if (PlayerPrefs.GetInt("wearing") == 3)
        {
            PurpleSkin();
        }
        else if (PlayerPrefs.GetInt("wearing") == 4)
        {
            OrangeSkin();
        }
        else if (PlayerPrefs.GetInt("wearing") == 5)
        {
            PinkSkin();
        }
        else if (PlayerPrefs.GetInt("wearing") == 6)
        {
            TurqSkin();        
        }
        else if (PlayerPrefs.GetInt("wearing") == 7)
        {
            BrownSkin();
        }
        else if (PlayerPrefs.GetInt("wearing") == 8)
        {
            GreenSkin();
        }
        else if (PlayerPrefs.GetInt("wearing") == 9)
        {
            GreySkin();
        }
        else if (PlayerPrefs.GetInt("wearing") == 10)
        {
            GhostSkin();
        }
        else if (PlayerPrefs.GetInt("wearing") == 11)
        {
            SilverSkin();  
        }
        else if (PlayerPrefs.GetInt("wearing") == 12)
        {
            GoldSkin();
            Debug.Log("GOLD");
        }
        else if (PlayerPrefs.GetInt("wearing") == 13)
        {
            GalaxySkin();
        }
/*
        for (int i = 0; i < 14; i++)
        {
            if (PlayerPrefs.GetInt("wearing") == i)
            {

            }
        }
        */
        
    }
}
