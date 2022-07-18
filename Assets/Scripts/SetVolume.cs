using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider slider;

    private void Awake()
    {
        awakeCheck();
    }

    private void Update()
    {
        //Debug.Log(slider.value);

        if (Math.Abs(PlayerPrefs.GetFloat("sliderValue") - slider.value) >= 0.01)
        {
            PlayerPrefs.SetFloat("sliderValue", slider.value);
            
        }
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    private void awakeCheck()
    {
        if (!PlayerPrefs.HasKey("sliderValue"))
        {
            PlayerPrefs.SetFloat("sliderValue", 1);
            slider.value = 1;
        }
        else
        {
            slider.value = PlayerPrefs.GetFloat("sliderValue");
        }
    }
}
