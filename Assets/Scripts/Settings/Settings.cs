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
    private int resolution;
    private bool fullscreen;
    private int quality;
    private float masterVolume;
    private float soundFXVolume;
    private float musicVolume;
    private float ambientVolume;

    [Header("UI Elements")]
    [SerializeField]
    private TMP_Dropdown resolutionDropdown;
    [SerializeField]
    private Toggle fullScreenToggle;
    [SerializeField]
    private TMP_Dropdown qualityDropdown;
    [SerializeField]
    private Slider masterVolumeSlider;
    [SerializeField]
    private Slider soundFXVolumeSlider;
    [SerializeField]
    private Slider musicVolumeSlider;
    [SerializeField]
    private Slider ambientVolumeSlider;

    [Header("Default Settings")]
    [SerializeField]
    private int default_resolution = 0;
    [SerializeField]
    private bool default_fullscreen = false;
    [SerializeField]
    private int default_quality = 0;
    [SerializeField]
    private float default_masterVolume = 1.0f;
    [SerializeField]
    private float default_soundFXVolume = 1.0f;
    [SerializeField]
    private float default_musicVolume = 1.0f;
    [SerializeField]
    private float default_ambientVolume = 1.0f;

    private void Start()
    {
        loadSettings();
        UIElementUpdate();
    }

    /// <summary>
    /// Load settings from player prefs
    /// </summary>
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

    /// <summary>
    /// Save settings to player prefs then update UI
    /// </summary>
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

    /// <summary>
    /// Reset all variables to default
    /// then update ui
    /// </summary>
    public void resetToDefault()
    {
        resolution = default_resolution;
        fullscreen = default_fullscreen;
        quality = default_quality;
        masterVolume = default_masterVolume;
        soundFXVolume = default_soundFXVolume;
        musicVolume = default_musicVolume;
        ambientVolume = default_ambientVolume;

        UIElementUpdate();
    }

    /// <summary>
    /// Update the UI elements with information stored in this component
    /// </summary>
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
