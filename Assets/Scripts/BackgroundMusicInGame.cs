using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BackgroundMusicInGame : MonoBehaviour
{

    public AudioMixer mixer;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.volume = 0.3f;

        //audioSource.mute = true;
        
        if (!PlayerPrefs.HasKey("sliderValue"))
        {
            PlayerPrefs.SetFloat("sliderValue", 1);
        }
        
        Debug.Log(PlayerPrefs.GetFloat("sliderValue"));
        
        mixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("sliderValue")) * 20);
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }
    
    public void ResumeMusic()
    {
        audioSource.UnPause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
