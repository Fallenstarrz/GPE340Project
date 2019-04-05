using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    [Header("Resources")]
    public VolumeSliderController audioController;

    [Header("Current Settings")]
    public int resolution;
    public bool fullscreen;
    public int quality;
    public float masterVolume;
    public float soundFXVolume;
    public float musicVolume;
    public float ambientVolume;

    [Header("UI Elements")]
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullScreenToggle;
    public TMP_Dropdown qualityDropdown;
    public Slider masterVolumeSlider;
    public Slider soundFXVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider ambientVolumeSlider;

    [Header("Default Settings")]
    public int default_resolution = 0;
    public bool default_fullscreen = false;
    public int default_quality = 0;
    public float default_masterVolume = 1.0f;
    public float default_soundFXVolume = 1.0f;
    public float default_musicVolume = 1.0f;
    public float default_ambientVolume = 1.0f;

    private void Start()
    {
        loadSettings();
        UIElementUpdate();
    }

    public void loadSettings()
    {
        resolution = PlayerPrefs.GetInt("resolution");
        int value = PlayerPrefs.GetInt("fullscreen");
        if (value == 1)
        {
            fullscreen = true;
        }
        else
        {
            fullscreen = false;
        }
        quality = PlayerPrefs.GetInt("quality");
        masterVolume = PlayerPrefs.GetFloat("masterVolume");
        soundFXVolume = PlayerPrefs.GetFloat("soundFXVolume");
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        ambientVolume = PlayerPrefs.GetFloat("ambientVolume");
    }

    public void saveSettings()
    {
        resolution = resolutionDropdown.value;
        fullscreen = fullScreenToggle.isOn;
        quality = qualityDropdown.value;
        masterVolume = masterVolumeSlider.value;
        soundFXVolume = soundFXVolumeSlider.value;
        musicVolume = musicVolumeSlider.value;
        ambientVolume = ambientVolumeSlider.value;

        PlayerPrefs.SetInt("resolution", resolution);
        if (fullscreen == true)
        {
            PlayerPrefs.SetInt("fullscreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("fullscreen", 0);
        }
        PlayerPrefs.SetInt("quality", quality);
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
        PlayerPrefs.SetFloat("soundFXVolume",soundFXVolume);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("ambientVolume", ambientVolume);

        UIElementUpdate();
    }

    public void resetToDefault()
    {
        resolution = default_resolution;
        fullscreen = default_fullscreen;
        quality = default_quality;
        masterVolume = default_masterVolume;
        soundFXVolume = default_soundFXVolume;
        musicVolume = default_musicVolume;
        ambientVolume = default_musicVolume;

        UIElementUpdate();
    }

    private void UIElementUpdate()
    {
        // This setting doesn't get set properly :( I have no frickin clue why...
        resolutionDropdown.value = resolution;
        fullScreenToggle.isOn = fullscreen;
        qualityDropdown.value = quality;
        masterVolumeSlider.value = masterVolume;
        soundFXVolumeSlider.value = soundFXVolume;
        musicVolumeSlider.value = musicVolume;
        ambientVolumeSlider.value = ambientVolume;

        audioController.setMasterVolume(masterVolume);
        audioController.setSoundFXVolume(soundFXVolume);
        audioController.setMusicVolume(musicVolume);
        audioController.setAmbientVolume(ambientVolume);
    }
}
