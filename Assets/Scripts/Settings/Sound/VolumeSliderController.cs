using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSliderController : MonoBehaviour
{
    [SerializeField]
    private AudioMixer mixer;

    public void setMasterVolume(float value)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }

    public void setMusicVolume(float value)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    public void setAmbientVolume(float value)
    {
        mixer.SetFloat("AmbienceVolume", Mathf.Log10(value) * 20);
    }

    public void setSoundFXVolume(float value)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
    }
}
