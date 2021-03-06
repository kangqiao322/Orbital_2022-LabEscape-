using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//handles Shop GUI and buying/equipping 
//all skins id must start from 1
//id = 0 for default skin
public class ButtonAction : MonoBehaviour
{
    private Transform trans;
    private Button button;
    private TextMeshProUGUI TMPtext;
    private Image gemImage;
    private int itemCost;

    private StoreManager storeManager;

    private bool isBought;
    private bool isEquipped;
    private int totalGems;

    [SerializeField] private int id;
    
    void Awake()
    {

        trans = GetComponent<Transform>();
        button = trans.GetComponent<Button>();
        TMPtext = trans.GetComponentInChildren<TextMeshProUGUI>();
        itemCost = int.Parse(TMPtext.text);
        gemImage = trans.GetComponentsInChildren<Image>()[1];

        storeManager = FindObjectOfType<StoreManager>();

        isBought = PlayerPrefs.GetInt("bought_" + id) == 1;
        isEquipped = PlayerPrefs.GetInt("wearing") == id;

        if (!isBought)
        {
            //makes the button clicking function to grab the cost displayed
            button.onClick.AddListener(() => TryToBuy(itemCost));
        }
        else if (!isEquipped)
        {
            ChangeButtonToEquip(false); //optional parameter
            //false because from main menu -> shop you dont want it to produce sound
            //since the button is supposed to be at "Equip" already
        }
        else //meaning it is currently equipped
        {
            ChangeButtonToIsEquipped();
        }
        
    }

    private void TryToBuy(int cost)
        //when this method is called the skin is alr guaranteed to be not bought yet
    {
        totalGems = PlayerPrefs.GetInt("totalGem");
        
        if (totalGems >= cost)
        {
            storeManager.playAudioNumber(0);
            Debug.Log("enough gems to buy");
            PlayerPrefs.SetInt("bought_" + id, 1);
            isBought = true;
            totalGems -= cost;
            PlayerPrefs.SetInt("totalGem", totalGems);

            ChangeButtonToEquip(false);
        }
        else
        {
            storeManager.playAudioNumber(1);
            Debug.Log("not enough gems");
        }
    }

    //
    //now this button contains the method to switch to is equipped after pressing
    private void ChangeButtonToEquip(bool needSound = true) //by default sounds are played
    {
        if (gemImage != null)
        {
            Destroy(gemImage);
        }
        
        isBought = true;
        isEquipped = false;
        TMPtext.text = "Equip";
        TMPtext.fontSize = 20;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ChangeButtonToIsEquipped);

        if (needSound)
        {
            // Debug.Log(id);
            storeManager.playAudioNumber(2);
        }
    }

    private void ChangeButtonToIsEquipped()
    {
        Debug.Log("currently equipped skin is " + id);
        
        if (gemImage != null)
        {
            Destroy(gemImage);
        }
        
        isBought = true;
        isEquipped = true;
        TMPtext.text = "Equipped";
        TMPtext.fontSize = 15;
        
        PlayerPrefs.SetInt("wearing", id);
        storeManager.updateAllButtons();

        button.onClick.RemoveAllListeners();
    }

    public void updateOwnButton()
    //need this method since 2 buttons can be equipped due to not updating
    {
        int currentlyWearing = PlayerPrefs.GetInt("wearing");
        
        if (!isBought || this.id == currentlyWearing)
        {
            return;
        }
        
        //if code reach here it means that this skin has been bought
        //and is not supposed to be equipped (but its isEquipped is true)

        if (isEquipped)
        {
            ChangeButtonToEquip();
        }
    }
    
    
}
