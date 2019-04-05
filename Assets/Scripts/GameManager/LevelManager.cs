using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public HUD hudReference;
    public SceneSwitcher sceneSwapper;
    public Settings settingsMenu;
    /// <summary>
    /// Reset Game to default state determined by game manager
    /// </summary>
    void Start()
    {
        if (hudReference != null)
        {
            GameManager.instance.headsUpDisplay = hudReference;
        }
        GameManager.instance.sceneSwitcher = sceneSwapper;
        GameManager.instance.settings = settingsMenu;
    }
}
