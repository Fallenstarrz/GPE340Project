using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSliderController : MonoBehaviour
{
    [SerializeField]
    private AudioMixer mixer;

    /// <summary>
    /// Set Master volume by taking the value of the slider and setting sound mixer to that value
    /// Formula is Log10(value)*20 to make it a linear increase/decrease
    /// </summary>
    /// <param name="value">value to set sound mixer to</param>
    public void setMasterVolume(float value)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }

    /// <summary>
    /// Set Music volume by taking the value of the slider and setting sound mixer to that value
    /// Formula is Log10(value)*20 to make it a linear increase/decrease
    /// </summary>
    /// <param name="value">value to set sound mixer to</param>
    public void setMusicVolume(float value)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    /// <summary>
    /// Set Ambient volume by taking the value of the slider and setting sound mixer to that value
    /// Formula is Log10(value)*20 to make it a linear increase/decrease
    /// </summary>
    /// <param name="value">value to set sound mixer to</param>
    public void setAmbientVolume(float value)
    {
        mixer.SetFloat("AmbienceVolume", Mathf.Log10(value) * 20);
    }

    /// <summary>
    /// Set Sound FX volume by taking the value of the slider and setting sound mixer to that value
    /// Formula is Log10(value)*20 to make it a linear increase/decrease
    /// </summary>
    /// <param name="value">value to set sound mixer to</param>
    public void setSoundFXVolume(float value)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
    }
}
