using System;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    
    public bool adminModeResetSkins = true;
    //if true, every time game is launched there are no bought skins
    //and wearing id is set to 0 
    //sometimes this function is called too late
    
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
        
        //PlayerPrefs.SetInt("totalGem", 50000);
        
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
