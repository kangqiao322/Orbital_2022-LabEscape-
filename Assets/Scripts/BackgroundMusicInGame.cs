using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicInGame : MonoBehaviour
{

    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        //audioSource.mute = true;
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
