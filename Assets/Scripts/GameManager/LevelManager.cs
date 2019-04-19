using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public HUD hudReference;
    public SceneSwitcher sceneSwapper;
    public Settings settingsMenu;

    public List<ActorSpawner_Enemy> enemySpawnersInLevel;
    public ActorSpawner_Player playerSpawnerInLevel;
    /// <summary>
    /// Reset Game to default state determined by game manager
    /// </summary>
    void Start()
    {
        GameManager.instance.enemySpawners = enemySpawnersInLevel;
        GameManager.instance.playerSpawner = playerSpawnerInLevel;
        if (hudReference != null)
        {
            GameManager.instance.headsUpDisplay = hudReference;
        }
        GameManager.instance.sceneSwitcher = sceneSwapper;
        GameManager.instance.settings = settingsMenu;
        GameManager.instance.settings.loadSettings();
        GameManager.instance.resetGame();
    }
}
