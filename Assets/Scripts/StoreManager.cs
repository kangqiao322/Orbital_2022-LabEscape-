using System;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    
    private bool adminModeResetSkins = false;
    //if true, every time game is launched there are no bought skins
    //and wearing id is set to 0 
    //you need to reload the game twice for this to fully work
    //since it is called too slow the first time
    
    [SerializeField] private AudioClip[] sounds;
    private AudioSource _audioSource; //forced to create a dummy one to use PlayOneShot

    private void Awake()
    {
        if (adminModeResetSkins)
        {
            adminModeResetSkins = false;
            
            int n = Enum.GetNames(typeof(SkinInfo.SkinIDs)).Length;

            for (int i = 1; i < n + 1; i++)
            {
                PlayerPrefs.DeleteKey("bought_" + i);
            }
            
            PlayerPrefs.DeleteKey("wearing");
        }

        _audioSource = GetComponent<AudioSource>();
        
        //PlayerPrefs.SetInt("totalGem", 500);
        
        Debug.Log("wearing skin id " + PlayerPrefs.GetInt("wearing"));
    }

    public void updateAllButtons()
    {
        ButtonAction[] buttonScriptArray = GetComponentsInChildren<ButtonAction>();

        foreach (ButtonAction buttonAction in buttonScriptArray)
        {
            buttonAction.updateOwnButton();
        }
    }

    public void playAudioNumber(int i)
    {
        if (_audioSource == null) //idk why
        {
            _audioSource = GetComponent<AudioSource>();
        }

        _audioSource.PlayOneShot(sounds[i]);
    }
}
